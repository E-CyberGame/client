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
    private BoxCollider2D _colider;
    private Rigidbody2D _rigidbody;
    #endregion
    
    private NetworkTransform _nettransform;
    
    private LayerMask groundLayer;
    private LayerMask WallLayer;

    private float dashVelocity = 1.0f;
    private RaycastHit2D _hitGround;
    private RaycastHit2D _hitWallR;
    private RaycastHit2D _hitWallL;

    private bool dashable = true;

    public float wallCheckLine = 0.3f;
    public float groundCheckLine = 1f;
    public float jumpHeight = 2.0f;
    public float dashLength = 3.0f;
    public float slideRatio = 5.0f;

    [SerializeField]
    private Vector3 _velocity = new Vector3(0f, 0f, 0f);
    [SerializeField]
    private Vector3 _acceleration = new Vector3(0f, 0f, 0f);
    
    #region CurrentState
    public bool onGound = true;
    public bool onGravity = true;
    
    [SerializeField]
    public int jumpCount { get; private set; } = 0;
    public bool isJumping = false;
    public bool isPressing = false;
    private bool isDashing = false;
    
    public Vector2 currentDirectionX { get { return directionX == Vector2.zero ? beforeDirectionX : directionX; } }
    private float _directionAmount = 0.0f;

    private float DirectionAmount
    {
        get
        {
            return _directionAmount;
        }
        set
        {
            if (value > 1.0f)
            {
                _directionAmount = 1.0f;
            }

            else if (value < -1.0f)
            {
                _directionAmount = -1.0f;
            }
            else _directionAmount = value;
        }
    }
    [SerializeField]
    private Vector2 _directionX = Vector2.zero;
    
    public Vector2 directionX
    {
        get { return _directionX;}
        set
        {
            if (_directionX != value)
            {
                SyncDirectionX = _directionX;
            }
            _directionX = value;
            if (directionX != Vector2.zero)
                beforeDirectionX = directionX;
        }
    }

    public Vector2 beforeDirectionX = Vector2.left;
    public Vector2 SyncDirectionX = Vector2.zero;
    #endregion

    public void Awake()
    {
        _colider = GetComponent<BoxCollider2D>();
        _stat = GetComponent<ActorStat>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
        groundLayer = LayerMask.GetMask("Ground");
        WallLayer = LayerMask.GetMask("Wall");
    }

    public bool OnGround()
    {
        return onGound;
    }
    
    private bool GroundCheck()
    {
        Debug.DrawRay(_transform.position, Vector3.down * groundCheckLine, Color.red);
        _hitGround = Physics2D.Raycast(_transform.position, Vector3.down, groundCheckLine
            , groundLayer);
        if(_hitGround)
        {
            BoxCollider2D ground = _hitGround.collider as BoxCollider2D;
            float overlap = ground.bounds.max.y - _colider.bounds.min.y;
            if (overlap > 0)
                _transform.position += new Vector3(0, overlap, 0);
            return true;
        }
        return false;
    }

    private bool LWallCheck()
    {
        _hitWallL = Physics2D.Raycast(_transform.position, Vector3.left, wallCheckLine, WallLayer);
        if (_hitWallL)
        {
            return true;
        }
        return false;
    }
    private bool RWallCheck()
    {
        _hitWallR = Physics2D.Raycast(_transform.position, Vector3.right, wallCheckLine, WallLayer);
        if (_hitWallR)
        {
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
            if (directionX.x != SyncDirectionX.x)
            {
                if (directionX.x == 0)
                {
                    DirectionAmount += Time.deltaTime * (-SyncDirectionX.x) * slideRatio;
                    if (SyncDirectionX.x == -1.0f && DirectionAmount > 0f)
                    {
                        DirectionAmount = 0f;
                    }
                    else if (SyncDirectionX.x == 1.0f && DirectionAmount < 0f)
                    {
                        DirectionAmount = 0f;
                    }
                }
                else DirectionAmount += Time.deltaTime * directionX.x * slideRatio;
            }
            if(!isDashing)
                _velocity.x = DirectionAmount * (_stat.moveSpeed * Runner.DeltaTime);

            if (GroundCheck())
            {
                if (!onGound)
                {
                    _acceleration.y = 0f;
                    isJumping = false;
                }
                if(!isJumping)
                    _velocity.y = 0f;
                onGound = true;
            }
            else
            {
                if (onGravity) 
                    _acceleration.y -= 9.8f * Runner.DeltaTime;
                onGound = false;
            }
            
            
            _velocity += _acceleration * Runner.DeltaTime;
            
            if (isDashing || !onGravity) 
                _velocity.y = 0;

            if (LWallCheck() && _velocity.x < 0)
                _velocity.x = 0;

            if (RWallCheck() && _velocity.x > 0)
                _velocity.x = 0;

            _transform.position += _velocity;

            CheckFalling();
        }
    }

    private void CheckFalling()
    {
        if (_velocity.y <= -3f)
        {
            transform.position = new Vector3(0, 0, 0);
            _velocity.y = 0;
            _acceleration.y = 0;
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
        _velocity.y = 0.1f;
        _acceleration.y = 0.8f;
    }
    
    public void Down()
    {
        _velocity.y -= 0.2f;
        //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _stat.downSpeed * -1);
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
        onGravity = false;
    }

    public void GravityOn()
    {
        onGravity = true;
    }

    public void DashOn()
    {
        if (dashable)
        {
            GravityOFF();
            isDashing = true;
            _acceleration.x = currentDirectionX.x * (dashLength / _stat.dashTime);
            dashable = false;
            StartCoroutine(DashCoolDown());
        }
    }

    public float GetDashTime()
    {
        return _stat.dashTime / _stat.GetSpeed.Value;
    }

    public void DashOff()
    {
        GravityOn();
        isDashing = false;
        _acceleration.x = 0;
    }
    
    IEnumerator DashCoolDown()
    {
        yield return new WaitForSeconds(1.0f);
        dashable = true;
    }
}
