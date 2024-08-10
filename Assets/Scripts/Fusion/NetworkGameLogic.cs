using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class NetworkGameLogic : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private NetworkPrefabRef playerPrefab;
    [Networked, Capacity(5)] private NetworkDictionary<PlayerRef, NetPlayer> Players => default;


    public override void FixedUpdateNetwork()
    {
        bool areAllReady = true;
    }

    public void PlayerJoined(PlayerRef player)
    {
        if (HasStateAuthority)
        {
            NetworkObject playerObject = Runner.Spawn(playerPrefab, Vector3.up, Quaternion.identity, player);
            Players.Add(player, playerObject.GetComponent<NetPlayer>());
        }
    }

    public void PlayerLeft(PlayerRef player)
    {
        if(!HasStateAuthority)
        {
            return;
        }
        if (Players.TryGet(player, out NetPlayer playerBehaviour))
        {
            Players.Remove(player);
            Runner.Despawn(playerBehaviour.Object);
        }
    }
}
