using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    public Vector3[] SpawnPoints;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            NetworkObject networkObject = Runner.Spawn(PlayerPrefab, new Vector3(0, 1, 0), Quaternion.identity);
            networkObject.name = "MyPlayer";
        }
    }
}