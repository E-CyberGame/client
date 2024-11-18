using Actor.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHit : NetworkBehaviour, BHit
{
    [SerializeField] int _damage = 10;

    public void Hit(IHitted target)
    {
        Debug.Log("Hit");
        if (!HasStateAuthority) return;
        if (target == null) return;
        target.Hitted(_damage, LayerMask.NameToLayer("Enemy"));
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TriggerEnter");
        //���� ������ �� �ֵ� ���̾��...
        if (other.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        {
            Hit(other.GetComponent<IHitted>());
        }
    }
}
