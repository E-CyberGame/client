using Boss.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public enum GameState
{
    Waiting,
    Playing
}

public class NetworkGameLogic : NetworkBehaviour, IPlayerLeft
{
    [Networked, Capacity(5)] private NetworkDictionary<PlayerRef, NetPlayer> Players => default;
    [Networked, OnChangedRender(nameof(GameStateChanged))] private GameState State {  get; set; }

    public override void Spawned()
    {
        State = GameState.Waiting;
        NetUIMananger.Singleton.SetWaitUI(State);
    }
    
    public override void FixedUpdateNetwork()
    {
        if(Players.Count < 0)
        {
            return;
        }

        if (State == GameState.Waiting)
        {
            bool areAllReady = true;
            foreach (KeyValuePair<PlayerRef, NetPlayer> player in Players)
            {
                if (!player.Value.IsReady)
                {
                    areAllReady = false;
                    break;
                }
            }
            if (areAllReady)
            {
                State = GameState.Playing;
                PreparePlayers();
            }

        }
    }
    
    private void PreparePlayers()
    {
        Debug.Log("게임이 시작하므로 플레이어들은 준비하세요");
    }

    public void SetPlayer(PlayerRef player, NetworkObject playerObject)
    {
        if (player == Runner.LocalPlayer)
        {
            Players.Add(player, playerObject.GetComponent<NetPlayer>());
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        if (Players.TryGet(player, out NetPlayer playerBehaviour))
        {
            Players.Remove(player);
            Runner.Despawn(playerBehaviour.Object);
        }
    }

    private void GameStateChanged()
    {
        NetUIMananger.Singleton.SetWaitUI(State);
        BossSubway.Singleton.SkillStart();
    }
}
