using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSource : MonoBehaviour
{
    CloudSkill[] _cloudList;

    private void Start()
    {
        _cloudList = this.GetComponentsInChildren<CloudSkill>();
    }

    public void CloudSpawn()
    {
        for (int i = 0; i < _cloudList.Length; i++)
        {
            _cloudList[i].Activate();
        }
    }
}
