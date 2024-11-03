using Boss.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSkill : NetworkBehaviour, BSkill
{
    GameObject _cloud;
    float _pre = 1.0f;

    public void Activate()
    {
        StartCoroutine(CloudSpawn());
    }

    IEnumerator CloudSpawn()
    {
        _cloud = Resources.Load<GameObject>("Prefabs/Cloud".ToString());
        Runner.Spawn(_cloud, position: this.transform.position) ;
        yield return new WaitForSeconds(_pre);
    }
}
