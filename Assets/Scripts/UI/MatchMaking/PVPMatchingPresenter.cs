using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using UnityEngine;

public class PVPMatchingPresenter : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    public Transform RedTeamPanel;
    public Transform BlueTeamPanel;
    
    public GameObject CharacterPanel;
    public PVPSettingPanel SettingPanel;
    
    [Networked] private NetworkButtons StartButton { get; set; }

    [Networked] public NetworkLinkedList<PlayerRef> RedTeam { get; }
    [Networked] public NetworkLinkedList<PlayerRef> BlueTeam { get; }

    private Dictionary<PlayerRef, GameObject> panels = new Dictionary<PlayerRef, GameObject>();

    public override void Spawned()
    {
        Debug.Log("MatchingPresenter");
        
        if (HasStateAuthority)
        {
            PVPData data = FindObjectOfType<GameSettingData>().Data;
            SettingPanel.SetData(data);

            foreach (var player in Runner.ActivePlayers)
            {
                SetPlayerTeam(player);
            }
        }
        else
        {
            SettingPanel.SetData(RoomManager.Instance.GetGameSetting());
            SettingPanel.ChangeSetting -= RPC_ChangeData;
            SettingPanel.ChangeSetting += RPC_ChangeData;
        }
        
        
        foreach (var player in RedTeam)
        {
            SetPlayerPanel(player);
        }
        
        foreach (var player in BlueTeam)
        {
            SetPlayerPanel(player);
        }
    }
    
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_ChangeData(MapType mapType, bool crystal, bool decay)
    {
        RoomManager.Instance.SetGameSettting(new PVPData(mapType, decay, crystal));
        RPC_SetData(mapType, crystal, decay);
    }
    
    
    [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
    public void RPC_SetData(MapType mapType, bool crystal, bool decay)
    {
        SettingPanel.SetData(new PVPData(mapType, decay, crystal));
    }

    public void GameStart()
    {
        LoadingScene.SetGameScene("GameScene");
    }

    public void PlayerJoined(PlayerRef player)
    {
        if(HasStateAuthority) SetPlayerTeam(player);
        SetPlayerPanel(player);
    }

    private void SetPlayerTeam(PlayerRef player)
    {
        int redTeam = RedTeamPanel.childCount;
        int blueTeam = BlueTeamPanel.childCount;
        
        if (redTeam < blueTeam)
        {
            RedTeam.Add(player);
        }
        else
        {
            BlueTeam.Add(player);
        }
    }

    private void SetPlayerPanel(PlayerRef player)
    {
        GameObject go = Instantiate(CharacterPanel);
        panels[player] = go;

        if (RedTeam.Contains(player))
        {
            go.transform.SetParent(RedTeamPanel);
        }
        else
        {
            go.transform.SetParent(BlueTeamPanel);
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        Destroy(panels[player]);
        if (RedTeam.Contains(player))
        {
            RedTeam.Remove(player);
        }
        else
        {
            BlueTeam.Remove(player);
        }
    }
}
