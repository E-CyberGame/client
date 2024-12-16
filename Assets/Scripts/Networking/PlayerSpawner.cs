using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        PlayerPrefab = Resources.Load<GameObject>("Prefabs/Player/Network" + PlayerInfo.Instance.info.character.ToString());
        if (Runner.CanSpawn)
        {
            PlayerPrefab.name = player.ToString();
            Runner.Spawn(PlayerPrefab, inputAuthority: player);
        }
    }
}
