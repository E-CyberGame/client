using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SimulationBehaviour, IBeforeUpdate, INetworkRunnerCallbacks
{
    //public Player LocalPlayer;

    private PlayerNetworkInput accumulatedInput;
    private bool resetInput;

    void IBeforeUpdate.BeforeUpdate()
    {
        if (resetInput)
        {
            resetInput = false;
            accumulatedInput = default;
        }

        /*Keyboard keyboard = Keyboard.current;
        if (keyboard != null && (keyboard.enterKey.wasPressedThisFrame || keyboard.numpadEnterKey.wasPressedThisFrame || keyboard.escapeKey.wasPressedThisFrame))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        // Accumulate input only if the cursor is locked.
        if (Cursor.lockState != CursorLockMode.Locked)
            return;*/

        NetworkButtons moveButtons = default;
        NetworkButtons skillButtons = default;

        //if (keyboard != null)
        //{
            //if (keyboard.rKey.wasPressedThisFrame && LocalPlayer != null){}
                //LocalPlayer.RPC_SetReady();

            Vector2 moveDirection = Vector2.zero;
            
            if (Input.GetKey(KeyCode.LeftArrow))
                moveDirection += Vector2.left;
            if (Input.GetKey(KeyCode.RightArrow))
                moveDirection += Vector2.right;

            accumulatedInput.Direction += moveDirection;
            moveButtons.Set(InputButton.Jump, Input.GetKey(KeyCode.UpArrow));
            moveButtons.Set(InputButton.Down, Input.GetKey(KeyCode.DownArrow));
            moveButtons.Set(InputButton.Dash, Input.GetKey(KeyCode.LeftControl));
        //}
            skillButtons.Set(SkillButton.A, Input.GetKeyDown(KeyCode.A));
            skillButtons.Set(SkillButton.S, Input.GetKeyDown(KeyCode.S));
            skillButtons.Set(SkillButton.D, Input.GetKeyDown(KeyCode.D));
            skillButtons.Set(SkillButton.C, Input.GetKeyDown(KeyCode.C));
            skillButtons.Set(SkillButton.Attack, Input.GetKeyDown(KeyCode.X));

        accumulatedInput.MoveButtons = new NetworkButtons(accumulatedInput.MoveButtons.Bits | moveButtons.Bits);
        accumulatedInput.SkillButtons = new NetworkButtons(accumulatedInput.SkillButtons.Bits | skillButtons.Bits);
    }

    void INetworkRunnerCallbacks.OnConnectedToServer(NetworkRunner runner) { }

    void INetworkRunnerCallbacks.OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }

    void INetworkRunnerCallbacks.OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }

    void INetworkRunnerCallbacks.OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }

    void INetworkRunnerCallbacks.OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason) { }

    void INetworkRunnerCallbacks.OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }

    void INetworkRunnerCallbacks.OnInput(NetworkRunner runner, NetworkInput input)
    {
        accumulatedInput.Direction.Normalize();
        input.Set(accumulatedInput);
        resetInput = true;
    }

    void INetworkRunnerCallbacks.OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }

    void INetworkRunnerCallbacks.OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    void INetworkRunnerCallbacks.OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player) { }

    void INetworkRunnerCallbacks.OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        /*if (player == runner.LocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }*/
    }

    void INetworkRunnerCallbacks.OnPlayerLeft(NetworkRunner runner, PlayerRef player) { }

    void INetworkRunnerCallbacks.OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress) { }

    void INetworkRunnerCallbacks.OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data) { }

    void INetworkRunnerCallbacks.OnSceneLoadDone(NetworkRunner runner) { }

    void INetworkRunnerCallbacks.OnSceneLoadStart(NetworkRunner runner) { }

    void INetworkRunnerCallbacks.OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }

    async void INetworkRunnerCallbacks.OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void INetworkRunnerCallbacks.OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }
}
