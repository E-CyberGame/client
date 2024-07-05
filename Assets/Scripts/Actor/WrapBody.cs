using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//도메인
public class WrapBody : MonoBehaviour
{
    public ActorStat _stat { get; private set; }
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private RaycastHit2D _hitGround;
    public Vector2 directionX = Vector2.zero;
    public Vector2 beforeDirectionX = Vector2.zero;
    private LayerMask groundLayer;
    private Vector2 velocity;
    private float dashVelocity = 1.0f;
    public int jumpCount { get; private set; } = 0;
    private bool isPressing { get { return directionX.x != 0 ? true : false;  } }
    private bool isDashing = false;
    
    public float groundCheckLine = 0.5f;

    public float jumpHeight = 2.0f;
    public float dashLength = 3.0f;

    public void Awake()
    {
        _stat = GetComponent<ActorStat>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
        groundLayer = LayerMask.GetMask("Ground");
    }
    
    public bool OnGround()
    {
        //?? 문제가 해결되지 않음.
        Debug.DrawRay(_transform.position, Vector3.down * groundCheckLine, Color.red);
        _hitGround = Physics2D.Raycast(_transform.position, Vector3.down, groundCheckLine
            , groundLayer);
        if(_hitGround) {
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
        if (directionX != Vector2.zero)
            beforeDirectionX = directionX;
    }

    public void FixedUpdate()
    {
        //가속 구현 -> isPressing
        velocity = directionX * _stat.moveSpeed * _stat.speed;

        if (isDashing)
        {
            velocity = beforeDirectionX * _stat.speed * dashVelocity;
        }
        _rigidbody.velocity = new Vector2(velocity.x, _rigidbody.velocity.y);
    }

    public void ResetJumpCount()
    {
        jumpCount = 0;
    }

    public void Jump()
    {
        float vel = (jumpHeight / _stat.jumpTime) * _rigidbody.gravityScale;
        Debug.Log(vel);
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, vel);
        jumpCount++;
    }
    
    public void Down()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _stat.speed * _stat.downSpeed * -1);
        Debug.Log("Down");
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
