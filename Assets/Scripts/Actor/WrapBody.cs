using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//도메인
public class WrapBody : NetworkBehaviour
{
    #region Reference
    private ActorStat _stat;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    #endregion
    
    private NetworkTransform _nettransform;
    
    private LayerMask groundLayer;
    
    private float dashVelocity = 1.0f;
    private RaycastHit2D _hitGround;

    public bool onGound = false;
    public bool isJumping = false;
    public int jumpCount { get; private set; } = 0;
    public float groundCheckLine = 1.05f;
    public float jumpHeight = 2.0f;
    public float dashLength = 3.0f;
    
    #region CurrentState(is ~ing)

    public bool isPressing = false;
    private bool isDashing = false;
    
    public Vector2 currentDirectionX { get { return directionX == Vector2.zero ? beforeDirectionX : directionX; } }
    [SerializeField]
    private Vector2 _directionX = Vector2.zero;
    
    public Vector2 directionX
    {
        get { return _directionX;}
        set
        {
            _directionX = value;
            if (directionX != Vector2.zero)
                beforeDirectionX = directionX;
        }
    }

    public Vector2 beforeDirectionX = Vector2.left;
    #endregion

    public void Awake()
    {
        _stat = GetComponent<ActorStat>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
        groundLayer = LayerMask.GetMask("Ground");
    }

    public bool OnGround()
    {
        return onGound;
    }
    
    private bool GroundCheck()
    {
        Debug.DrawRay(_transform.position, Vector3.down * 1.05f, Color.red);
        _hitGround = Physics2D.Raycast(_transform.position, Vector3.down, groundCheckLine
            , groundLayer);
        if(_hitGround)
        {
            isJumping = false;
            return true;
        }
        return false;
    }

    public bool CanJump()
    {
        return _stat.MaxJumpCount <= jumpCount;
    }
    
    public void Move(Vector2 directionX)
    {
        this.directionX = directionX;
    }

    public override void FixedUpdateNetwork()
    {
        if (HasStateAuthority)
        {
            float velocityX = directionX.x * (_stat.moveSpeed * _stat.speed * Runner.DeltaTime);
            float velocityY = 0f;
            
            if (isJumping)
            {
                //사실 로직이 말이 안되긴 함... 시간이 갈 수록 속도가 줄어야... 줄기는 하는데... 하...
                //계산상으로는 에반데 프로그램이라 돌아가는 것 같음. (GroundCheck이랑 틱 이슈)
                //하... 물리tlqkf새끼야....
                //그냥 최초 힘... 최초 힘 부여하고 ... 하.. Gravity 로 떨어지는 걸로 계산 수정하자
                velocityY = (jumpHeight / _stat.jumpTime) * Runner.DeltaTime * 3f;
            }
            
            if (isDashing)
            {
                velocityX = beforeDirectionX.x * _stat.speed * dashVelocity * Runner.DeltaTime;
            }

            if (GroundCheck())
            {
                Debug.Log("아니 그라운드 들어왔으면 멈추라고 쫌");
                onGound = true;
            }
            else
            {
                velocityY -= _stat.gravity * Runner.DeltaTime;
                onGound = false;
            }
            
            Debug.Log(velocityY);

            _transform.position += new Vector3(velocityX, velocityY, 0);
        }
    }

    public void ResetJumpCount()
    {
        jumpCount = 0;
    }

    public void Jump()
    {
        isJumping = true;
        jumpCount++;
    }
    
    public void Down()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _stat.downSpeed * -1);
    }

    public void StartHitted()
    {
        _transform.position = new Vector3(_transform.position.x + currentDirectionX.x * -1.0f, _transform.position.y, 0f);
        directionX = Vector2.zero;
    }

    public void EndHitted()
    {
        if(isPressing)
            directionX = beforeDirectionX;
    }

    public void GravityOFF()
    {
        _rigidbody.gravityScale = 0f;
    }

    public void GravityOn()
    {
        _rigidbody.gravityScale = 3;
    }

    public void DashOn()
    {
        GravityOFF();
        isDashing = true;
        dashVelocity = dashLength / _stat.dashTime;
    }

    public float GetDashTime()
    {
        return _stat.dashTime / _stat.speed;
    }

    public void DashOff()
    {
        GravityOn();
        isDashing = false;
        dashVelocity = 1f;
    }
}
