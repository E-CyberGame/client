using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WrapBody
{
    private ActorStat _stat;
    private RaycastHit _hitGround;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    
    public WrapBody(ActorStat stat, Transform tr, Rigidbody2D rigid)
    {
        _stat = stat;
        _transform = tr;
        _rigidbody = rigid;
    }

    public bool OnGround()
    {
        //Physics2D 문제인듯. 그리고 Ray는 따로 빼두는 게 성능에 이로울듯
        Debug.DrawRay(_transform.position, Vector3.down * _stat.groundCheckLine, Color.red);
        if(Physics.Raycast(_transform.position, Vector3.down, out _hitGround, _stat.groundCheckLine))
        {
            Debug.Log(_hitGround.collider.gameObject.layer);
            if(_hitGround.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
        }
        
        return false;
    }
    
    public void OnMove(Vector2 horizontal)
    {
        Debug.Log("Move" + horizontal);
    }

    public void OnJump()
    {
        Debug.Log("Jump");
    }
    
    public void OnDown()
    {
        Debug.Log("Down");
    }
}
