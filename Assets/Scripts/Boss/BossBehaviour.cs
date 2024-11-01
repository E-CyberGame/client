using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : NetworkBehaviour
{
    [Networked] public float Health { get; set; }
    [SerializeField] GameObject _boss;


    public void Start()
    {
        /*
        if(_boss != null && Runner.IsServer)
        {
        }
        */
        StartCoroutine(StartSpawnRoutine());
    }

    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_SpawnBoss()
    {
        _boss.SetActive(true);
    }

    IEnumerator StartSpawnRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Load Boss");
        RPC_SpawnBoss();
    }

}
