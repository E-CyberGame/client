using Actor.Skill;
using Boss.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : NetworkBehaviour, BHit
{
    public float speed = 0.03f;
    NetworkObject rock_net;
    private bool move = false;
    private Vector3 origin_pos;
    public float delay;
    [SerializeField] int _damage = 8;

    public override void Spawned()
    {
        rock_net = GetComponent<NetworkObject>();
        origin_pos = transform.position;
        StartCoroutine(BeforeFall());
    }

    public override void FixedUpdateNetwork()
    {
        Vector3 current = transform.position;
        Vector3 target = origin_pos + new Vector3(0, -5.5f, 0);
        if (current == target && HasStateAuthority)
        {
            move = false;
            StartCoroutine(HitGround());
        }
        if (move)
        {
            transform.position = Vector3.MoveTowards(current, target, speed);
        }
    }

    IEnumerator BeforeFall()
    {
        yield return new WaitForSeconds(delay);
        move = true;
    }

    IEnumerator HitGround()
    {
        yield return new WaitForSeconds(0.2f);
        Runner.Despawn(rock_net);
    }
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
        //추후 때려야 할 애들 레이어로...
        if (other.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        {
            Hit(other.GetComponent<IHitted>());
        }
    }

}
