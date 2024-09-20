using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Data;
using Fusion;
using UnityEngine;

public class RoomManager : NetworkBehaviour
{
    public static RoomManager Instance { get; private set; }

    #region RoomProperty
    [Networked] public MapType MapType { get; set; }
    [Networked] public bool BetCrystal { get; set; }
    [Networked] public bool BetDecay { get; set; }
    #endregion
    
    public void SetGameSettting(PVPData data)
    {
        MapType = data.SceneType;
        BetCrystal = data.Crystal;
        BetDecay = data.Decay;
    }

    public PVPData GetGameSetting()
    {
        return new PVPData(MapType, BetDecay, BetCrystal);
    }

    public override void Spawned()
    {
        Instance = this;
        FindObjectOfType<GameSettingData>().RPC_SetGameData();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
