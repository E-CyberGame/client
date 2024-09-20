using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using UnityEngine;

public class GameSettingData : MonoBehaviour
{
    public PVPData Data { get; set; }

    public void Start()
    {
        DontDestroyOnLoad(this);
    }
}
