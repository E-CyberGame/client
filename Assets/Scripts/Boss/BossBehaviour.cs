using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : SimulationBehaviour
{
    [Networked] public float Health { get; set; }
    [SerializeField] GameObject BossPrefab;


    public void Start()
    {
        //StartCoroutine(StartSpawnRoutine());
    }

    /*
    IEnumerator StartSpawnRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        Debug.Log("Load Boss");
    }    
    */
}
