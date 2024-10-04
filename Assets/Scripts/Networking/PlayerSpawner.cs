using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        if (Runner.CanSpawn)
        {
            PlayerPrefab.name = player.ToString();
            Runner.Spawn(PlayerPrefab, inputAuthority: player);
        }
    }
}
