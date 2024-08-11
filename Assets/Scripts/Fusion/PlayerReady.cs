using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReady : NetworkBehaviour
{
    [Networked]
    public bool ready { get; set; }

    void Update()
    {
        if (HasStateAuthority && Input.GetKeyDown(KeyCode.R) && !ready)
        {
            ready = true;
        }
    }

    void IsReady()
    {

    }
}
