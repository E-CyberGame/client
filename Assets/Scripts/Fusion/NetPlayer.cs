using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPlayer : NetworkBehaviour
{
    [Networked]
    public bool IsReady { get; set; }

    public override void Spawned()
    {
        if (HasInputAuthority)
        {
            Runner.GetComponent<InputManager>().LocalPlayer = this;
        }
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.InputAuthority | RpcTargets.StateAuthority)]
    public void RPC_SetReady()
    {
        IsReady = true;
        if (HasInputAuthority)
        {
            NetUIMananger.Singleton.DidSetReady();
        }
    }
}

