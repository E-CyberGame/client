using Actor.Skill;
using Boss.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SocialPlatforms;

public class CloudMove : NetworkBehaviour, BHit
{
    float speed = 0.005f;
    NetworkObject cloud_net;
    [SerializeField] int _damage = 8;

    public override void Spawned()
    {
        cloud_net = GetComponent<NetworkObject>();
    }

    public override void FixedUpdateNetwork()
    {
        if (BossCyber.Singleton == null)
        {
            Runner.Despawn(cloud_net);
        }
        else
        {
            Vector3 current = transform.position;
            Vector3 target = BossCyber.Singleton.GetTransform() + new Vector3(0, -1.0f, 0);
            if (current == target && HasStateAuthority)
            {
                BossCyber.Singleton.CloudReady();
                Runner.Despawn(cloud_net);
            }
            transform.position = Vector3.MoveTowards(current, target, speed);
        }
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

