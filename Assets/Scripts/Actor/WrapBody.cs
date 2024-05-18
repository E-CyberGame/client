using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WrapBody : MonoBehaviour
{
    private ActorStat _stat;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private RaycastHit2D _hitGround;
    public Vector2 directionX = Vector2.zero;
    private LayerMask groundLayer;
    private Vector2 velocity;
    private bool isPressing
    {
        get { return directionX.x != 0 ? true : false;  }
    }
    
    public float groundCheckLine = 0.5f;

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
    
    public void Move(Vector2 directionX)
    {
        this.directionX = directionX;
    }

    public void FixedUpdate()
    {
        //가속 구현용(미완)
        if (isPressing)
        {
            velocity = directionX * _stat.moveSpeed * Time.deltaTime;
        }
        else
        {
            velocity = directionX * _stat.moveSpeed * Time.deltaTime;
        }
        _rigidbody.velocity = new Vector2(velocity.x, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        Debug.Log("Jump");
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _stat.jumpSpeed);
    }
    
    public void Down()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _stat.downSpeed * -1);
        Debug.Log("Down");
    }
}
