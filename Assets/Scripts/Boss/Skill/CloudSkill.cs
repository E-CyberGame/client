using Boss.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSkill : MonoBehaviour, BSkill
{
    GameObject _cloud;
    float _pre = 1.0f;

    public void Activate()
    {
        StartCoroutine(CloudSpawn());
    }
    IEnumerator CloudSpawn()
    {
        _cloud = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Cloud"), transform.position);
        yield return new WaitForSeconds(_pre);
    }
}
