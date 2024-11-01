using Boss.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    float speed = 0.002f;
    
    private void Update()
    {
        Vector3 current = transform.position;
        Vector3 target = BossCyber.Singleton.GetTransform() + new Vector3 (0, -1.0f,0);
        if(current == target)
        {
            BossCyber.Singleton.CloudReady();
            Destroy (gameObject);
        }
        transform.position = Vector3.MoveTowards(current, target, speed);
    }

}

