using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public void PlayerJoined(PlayerRef player)
    {
        if (Runner.IsServer && player == Runner.LocalPlayer)
        {
            Runner.Spawn(PlayerPrefab);
        }
    }
}
