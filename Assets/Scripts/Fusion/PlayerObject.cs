using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Actor;
using Data;
using UnityEngine;
using Fusion;
using UnityEngine.InputSystem.HID;

public enum TeamType{
    RedTeam = 10,
    BlueTeam = 11
}

public class PlayerObject : NetworkBehaviour
{
    public const float TIME_UNSET = -1f;
    public const float TIME_DNF = 0xFFFF;
    public const int STROKES_DNF = int.MaxValue;

    public static PlayerObject Local { get; private set; }

    // Metadata
    [Networked]
    public PlayerRef Ref { get; set; }
    [Networked]
    public byte Index { get; set; }
    [Networked]
    public ActorController Controller { get; set; }

    // User Settings
    [Networked, OnChangedRender(nameof(StatChanged))]
    public string Nickname { get; set; }
    
    [Networked] 
    public CharacterType Character { get; set; }

    public bool IsReady;


    // State & Gameplay Info
    
    //팀에서 몇번째 플레이어인지
    [Networked] public int TeamNumber { get; set; }
    
    [Networked]
    public bool IsLoaded { get; set; }
    [Networked, OnChangedRender(nameof(SpectatorChanged))]
    public bool IsSpectator { get; set; }
    [Networked]
    public int Strokes { get; set; }
    [Networked, OnChangedRender(nameof(TimeTakenChanged))]
    public float TimeTaken { get; set; } // default set in inspector to -1
    public bool HasFinished => TimeTaken != TIME_UNSET;
    [Networked, Capacity(18)]
    public NetworkArray<byte> Scores { get; }
    public int TotalScore => Scores.Sum(s => s);

    public event System.Action OnStatChanged;
    public event System.Action OnSpectatorChanged;

    public void Server_Init(PlayerRef pRef, byte index)
    {
        Debug.Assert(Runner.IsServer);

        Ref = pRef;
        Index = index;
    }

    public override void Spawned()
    {
        Controller = GetComponent<ActorController>();
        if (Object.HasStateAuthority)
        {
            PlayerRegistry.Server_Add(Runner, Object.InputAuthority, this);
            Debug.Log("PlayerRegistry 등록이 완료되었습니다" + Ref);
        }

        //if (Local) AudioManager.Play("joinedSessionSFX");

        if (Object.HasInputAuthority)
        {
            Local = this;
            IsReady = false;
            Debug.Log("PlayerInfo" + Ref + PlayerInfo.Instance.info.name + PlayerInfo.Instance.info.character);
            Rpc_SetInfo(PlayerInfo.Instance.info.name, PlayerInfo.Instance.info.character);
            //Rpc_SetNickname(!string.IsNullOrWhiteSpace(UserData.Nickname) ? UserData.Nickname : $"Golfer{Random.Range(100, 1000)}");
        }
        
        Debug.Log("PlayerObject" + Ref + Nickname + Character.ToString());

        PlayerRegistry.PlayerJoined(Object.InputAuthority);
        
        DontDestroyOnLoad(this);
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (Local == this) Local = null;

        if (!runner.IsShutdown)
        {
            if (Controller)
            {
                runner.Despawn(Controller.Object);
            }
            
            if (GameManager.State.Current == GameState.EGameState.Game && PlayerRegistry.All(p => p.Controller == null))
            {
                GameManager.State.Server_SetState(GameState.EGameState.Outro);
            }
        }

    }

    public void ClearGameplayData()
    {
        Strokes = 0;
        TimeTaken = TIME_UNSET;
        for (int i = 0; i < Scores.Length; i++)
        {
            Scores.Set(i, 0);
        }
    }

    public void SetLayer(int layer)
    {
        gameObject.layer = layer;
    }
    public int GetLayer()
    {
        return gameObject.layer;
    }

    public void InitPlayerPosition(MapType type)
    {
        Controller.SetPlayerLocation(Database.MapData.GetData(type)
            .PlayerPosition[(TeamType)gameObject.layer][TeamNumber]);
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void Rpc_SetInfo(string nick, CharacterType characterType)
    {
        Nickname = nick;
        Character = characterType;
        
        Debug.Log("SetInfo" + Nickname + Character);
    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    public void Rpc_ToggleSpectate()
    {
        IsSpectator = !IsSpectator;
    }

    void StatChanged()
    {
        OnStatChanged?.Invoke();
    }

    void SpectatorChanged()
    {
        OnSpectatorChanged?.Invoke();
    }

    void TimeTakenChanged()
    {
        if (TimeTaken != TIME_UNSET)
        {
            if (Object.HasInputAuthority)
            {
                //HUD.ForceHideAll();
            }
        }
    }
}
