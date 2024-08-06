using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private RaycastHit2D _hitGround;
    public float groundCheckLine = 0.7f;
    private LayerMask groundLayer;
    GameObject _rock;

    public void Init(GameObject rock)
    {
        _transform = transform;
        groundLayer = LayerMask.GetMask("Ground");
        _rock = rock;
    }
    public void FixedUpdate()
    {
        Debug.DrawRay(_transform.position, Vector3.down * groundCheckLine, Color.red);
        _hitGround = Physics2D.Raycast(_transform.position, Vector3.down, groundCheckLine, groundLayer);
        if (_hitGround)
        {
            StartCoroutine(HitGround());
        }
    }

    IEnumerator HitGround()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.Destroy(_rock);
    }
}
