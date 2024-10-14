using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Data;
using Fusion;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RoomManager : NetworkBehaviour
{
    public static GameState State => Instance._gameState;
    [SerializeField] private GameState _gameState;
    public static RoomManager Instance { get; private set; }

    #region RoomSetting
    [Networked] public MapType MapType { get; set; }
    [Networked] public bool BetCrystal { get; set; }
    [Networked] public bool BetDecay { get; set; }
    
    public Action<PVPData> ChangeGameSetting = null;
    public Action BeforeGameStart = null;
    
    public void UpdateGameSetting()
    {
        ChangeGameSetting?.Invoke(GetGameSetting());
    }
    
    public void SetGameSettting(PVPData data)
    {
        MapType = data.SceneType;
        BetCrystal = data.Crystal;
        BetDecay = data.Decay;
    }
    
    public PVPData GetGameSetting()
    {
        return new PVPData(MapType, BetDecay, BetCrystal);
    }
    #endregion

    public override void Spawned()
    {
        Debug.Log("RoomManager");
        Instance = this;
        if(Runner.IsServer) SetGameSettting(FindObjectOfType<GameSettingData>().Data);
    }
    
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void Rpc_LoadDone(PlayerRef player)
    {
        PlayerRegistry.GetPlayer(player).IsLoaded = true;
    }
}
