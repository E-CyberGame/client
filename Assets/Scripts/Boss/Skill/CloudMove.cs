using Boss.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SocialPlatforms;

public class CloudMove : NetworkBehaviour
{
    float speed = 0.002f;
    NetworkObject cloud;
    [Networked] Vector3 cloud_position { get; set; }

    public override void Spawned()
    {
        cloud = GetComponent<NetworkObject>();
    }

    public override void FixedUpdateNetwork()
    {
        Vector3 current = transform.position;
        Vector3 target = BossCyber.Singleton.GetTransform() + new Vector3 (0, -1.0f,0);
        if(current == target && HasStateAuthority)
        {
            BossCyber.Singleton.CloudReady();
            Runner.Despawn(cloud);
        }
        cloud_position = Vector3.MoveTowards(current, target, speed);
        transform.position = cloud_position;
    }

}

