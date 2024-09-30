using Fusion;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    public PlayerObject PlayerObj { get; private set; }
    public override void Spawned()
    {
        PlayerObj = PlayerRegistry.GetPlayer(Object.InputAuthority);
        //PlayerObj.Controller = this;

        if (Object.HasInputAuthority)
        {
            //CameraController.AssignControl(this);
        }
        else
        {
            //Instantiate(ResourcesManager.Instance.worldNicknamePrefab, InterfaceManager.Instance.worldCanvas.transform).SetTarget(this);
        }
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        /*
        if (CameraController.HasControl(this))
        {
            CameraController.AssignControl(null);
        }
        */

        if (!runner.IsShutdown)
        {
            if (PlayerObj.TimeTaken != PlayerObject.TIME_UNSET)
            {
                //AudioManager.Play("ballInHoleSFX", AudioManager.MixerTarget.SFX, interpolationTarget.position);
            }
        }
    }
}
