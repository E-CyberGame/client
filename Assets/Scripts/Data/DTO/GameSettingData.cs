using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using UnityEngine;

public class GameSettingData : MonoBehaviour
{
    PVPData _data;

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SetGameData()
    {
        Debug.Log("RPC");
        RoomManager.Instance?.SetGameSettting(_data);
    }

    public void SetData(PVPData data)
    {
        _data = data;
    }

    public void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnEnable()
    {
        RPC_SetGameData();
    }
}
