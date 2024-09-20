using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using UnityEngine;

public class MatchingSetup : MonoBehaviour
{
    private PVPData _data;
    public void SetPVPData(PVPData data)
    {
        _data = data;
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void RPC_SendPVPData()
    {
        Instantiate(new GameObject("GameSettingData")).AddComponent<GameSettingData>()
            .Data = _data;
    }
    
    public void StartPVPGame(PVPData data)
    {
        if (Matchmaker.Instance.Runner == null)
        {
            RPC_SendPVPData();
            Matchmaker.Instance.TryHostSession();
        }
    }

    public void JoinPVPGame(string roomCode = null)
    {
        if (roomCode is null)
        {
            Matchmaker.Instance.TryJoinRandomSession();
        }
        else Matchmaker.Instance.TryJoinSession(roomCode);
    }
}
