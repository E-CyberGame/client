using Data;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class BossManager : NetworkBehaviour
{
    public static BossManager Instance { get; private set; }
    private GameObject BossPrefab;

    public override void Spawned()
    {
        Debug.Log("BossManager");
        Instance = this;
    }

    public void SetBoss(MapType type)
    {
        BossPrefab = Database.MapData.GetData(type).BossPrefab;
    }

    public void GameStart()
    {
        StartCoroutine(BossSpawnRoutine());
    }

    IEnumerator BossSpawnRoutine()
    {
        yield return new WaitForSeconds(10.0f);
        Runner.Spawn(BossPrefab);
    }

    public void SpawnBossObj(GameObject spawnObj)
    {

    }
    public void DeSpawnBossObj(GameObject despawnObj)
    {

    }
}
