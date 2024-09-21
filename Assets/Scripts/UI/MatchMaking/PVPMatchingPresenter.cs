using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PVPMatchingPresenter : NetworkBehaviour
{
    public Transform RedTeamPanel;
    public Transform BlueTeamPanel;
    public GameObject CharacterPanel;
    public PVPSettingPanel SettingPanel;
    public bool done = false;
    [Networked] private NetworkButtons StartButton { get; set; }

    public override void Spawned()
    {
        SettingPanel.RPC_SetGameData(FindObjectOfType<GameSettingData>().Data);
        
        int redTeam = RedTeamPanel.childCount;
        int blueTeam = BlueTeamPanel.childCount;
        NetworkObject go = Runner.Spawn(CharacterPanel);

        if (redTeam < blueTeam)
        {
            go.transform.SetParent(RedTeamPanel);
        }
        else go.transform.SetParent(BlueTeamPanel);
    }

    public void GameStart()
    {
        LoadingScene.SetGameScene("GameScene");
    }
}
