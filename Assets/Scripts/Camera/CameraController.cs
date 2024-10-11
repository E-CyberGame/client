using Cinemachine;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : NetworkBehaviour
{
    public static CameraController Instance { get; private set; }
    [SerializeField]
    CinemachineVirtualCamera localCamera;
    PlayerObject _local;


    private void Awake()
    {
        Instance = this;
        if(PlayerObject.Local == null)
        {
            Debug.Log("Cannot find Player");
        }
        else
        {
            _local = PlayerObject.Local;
        }
    }

    void Start()
    {
        if (localCamera != null)
        {
            Debug.Log("CameraSetting");
            localCamera.Follow = _local.transform;
        }
        else
        {
            Debug.Log("Camera Null");
        }
    }

}
