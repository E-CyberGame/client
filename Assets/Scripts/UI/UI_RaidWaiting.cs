using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEditor;
using Fusion;
using System.Resources;
using UnityEngine.UIElements;
using System.Linq;
using Helpers.Linq;
using System.Threading.Tasks;

public class UI_RaidWaiting : UI_Popup
{

    public UIScreen screen;
    private int playernum = 0; // 현재 입장한 플레이어 인원 수
    public GameObject playerProfileBG;
    //*******************************
    public float[,] positions = { { -680.0f, 0.0f }, { -340.0f, 0.0f }, { 0.0f, 0.0f }, { 340.0f, 0.0f }, { 680.0f, 0.0f } };
    //*******************************

    public Transform[] playerItemHolder;
    readonly Dictionary<PlayerRef, PlayerSessionItemUI> playerItems = new Dictionary<PlayerRef, PlayerSessionItemUI>();

    bool isUpdatingSession = false;
    public UnityEngine.UI.Button startGameButton;

    enum Buttons
    {
        PlayerEnterButton
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        //GetButton((int)Buttons.PlayerEnterButton).gameObject.BindUIEvent(PEButtonClicked);
    }

    public void PEButtonClicked(PointerEventData eventData)
    {
        Debug.Log("PlayerEnterButton Clicked");
        PlayerEntered();
    }

    public void PlayerEntered()
    {
        // Instance 생성
        GameObject playerObject = Resources.Load<GameObject>("Prefabs/PlayerWaiting");
        GameObject playerInstance = Instantiate(playerObject);

        // position 위치 지정
        playerInstance.transform.SetParent(playerProfileBG.transform);
        playerInstance.transform.localScale = Vector3.one;
        playerInstance.transform.localPosition = new Vector3(positions[playernum, 0], positions[playernum, 1],0);
        
        // player가 입장했으므로 playernum 증가
        playernum++;
    }

    // UI hook
    public void AddSubscriptions()
    {
        PlayerRegistry.OnPlayerJoined += PlayerJoined;
        PlayerRegistry.OnPlayerLeft += PlayerLeft;
    }

    private void OnEnable()
    {
        PlayerRegistry.OnPlayerJoined -= PlayerJoined;
        PlayerRegistry.OnPlayerLeft -= PlayerLeft;
        PlayerRegistry.OnPlayerJoined += PlayerJoined;
        PlayerRegistry.OnPlayerLeft += PlayerLeft;

        UpdateSessionConfig();
    }

    private void OnDisable()
    {
        playerItems.Clear();

        PlayerRegistry.OnPlayerJoined -= PlayerJoined;
        PlayerRegistry.OnPlayerLeft -= PlayerLeft;
    }

    private void Update()
    {
        if (GameManager.Instance?.Runner?.SessionInfo == true)
        {
            UpdateSessionConfig();
        }
    }

    public void UpdateSessionConfig()
    {
        if (!isUpdatingSession && gameObject.activeInHierarchy)
        {
            isUpdatingSession = true;
            StartCoroutine(UpdateSessionConfigRoutine());
        }
    }

    IEnumerator UpdateSessionConfigRoutine()
    {
        if (!(GameManager.Instance?.Runner?.SessionInfo == true))
        {
            yield return new WaitUntil(() => GameManager.Instance?.Runner?.SessionInfo == true);
        }

        if (GameManager.Instance.Runner.IsServer)
        {
            //Debug.Log(PlayerRegistry.CountAll);
            PlayerRegistry.ForEach(p =>
            {
                if (!playerItems.ContainsKey(p.Ref))
                {
                    CreatePlayerItem(p.Ref);
                }
            });
        }

        startGameButton.gameObject.SetActive(GameManager.Instance.Runner.IsServer);

        isUpdatingSession = false;
    }

    public void PlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        CreatePlayerItem(player);
    }

    private void CreatePlayerItem(PlayerRef pRef)
    {
        if (!playerItems.ContainsKey(pRef))
        {
            if (GameManager.Instance.Runner.CanSpawn)
            {
                PlayerSessionItemUI item = GameManager.Instance.Runner.Spawn(
                    prefab: ScriptManager.Instance.playerSessionItemUI,
                    inputAuthority: pRef);
                playerItems.Add(pRef, item);
            }
        }
        else
        {
            Debug.LogWarning($"{pRef} already in dictionary");
        }
    }

    public void PlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        if (playerItems.TryGetValue(player, out PlayerSessionItemUI item))
        {
            if (item)
            {
                Debug.Log($"Removing {nameof(PlayerSessionItemUI)} for {player}");
                runner.Despawn(item.Object);
            }
            else
            {
                Debug.Log($"{nameof(PlayerSessionItemUI)} for {player} was null.");
            }
            playerItems.Remove(player);
        }
        else
        {
            Debug.LogWarning($"{player} not found");
        }
    }

    public void StartGame()
    {
        if (PlayerRegistry.CountPlayers > 0)
        {
            GameManager.State.Server_SetState(GameState.EGameState.Loading);
        }
    }

    public void ToggleSpectate()
    {
        PlayerObject.Local.Rpc_ToggleSpectate();
    }

    public void Leave()
    {
        StartCoroutine(LeaveRoutine());
    }

    IEnumerator LeaveRoutine()
    {
        Task task = Matchmaker.Instance.Runner.Shutdown();
        while (!task.IsCompleted)
        {
            yield return null;
        }
        UIScreen.BackToInitial();
    }

    public Transform getPlayerHolder()
    {
        Transform playerHolder = playerItemHolder[playernum];

        return playerHolder;
    }
}
