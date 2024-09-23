using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : NetworkBehaviour, INetworkRunnerCallbacks
{
    public static GameState State => Instance._gameState;
    [SerializeField] private GameState _gameState;

    public static GameManager Instance { get; private set; }


    void OnSessionConfigChanged()
    {
        InterfaceManager.Instance.sessionScreen.UpdateSessionConfig();
    }

    public override void Spawned()
    {
        Instance = this;
        Runner.AddCallbacks(this);
        if (Runner.IsServer)
        {
            if (Runner.SessionInfo.IsVisible != !SessionSetup.isPrivate)
                Runner.SessionInfo.IsVisible = !SessionSetup.isPrivate;
        }
        /*
        if (State.Current < GameState.EGameState.Loading)
        {
            UIScreen.Focus(InterfaceManager.Instance.sessionScreen.screen);
        }
        */
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        Instance = null;
    }


    public void OnSceneLoadDone(NetworkRunner runner)
    {
        if (runner.SimulationUnityScene.name == "Game")
        {
            //Level.Load(ResourcesManager.Instance.levels[CurrentHole]);
        }
    }

    [Rpc(RpcSources.All, RpcTargets.StateAuthority, HostMode = RpcHostMode.SourceIsHostPlayer)]
    public void Rpc_LoadDone(RpcInfo info = default)
    {
        PlayerRegistry.GetPlayer(info.Source).IsLoaded = true;
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        if (shutdownReason != ShutdownReason.Ok)
        { 
            //DisconnectUI.OnShutdown(shutdownReason); 
        }

    }

    #region INetworkRunnerCallbacks
    public void OnConnectedToServer(NetworkRunner runner) { }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnDisconnectedFromServer(NetworkRunner runner) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) { }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }

    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data) { }
    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }
    #endregion
}
