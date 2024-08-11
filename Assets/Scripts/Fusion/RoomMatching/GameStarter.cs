using System.Linq;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData
{
    public string Name;
    public int Id; // 또는 PlayerRef 타입으로 변경 가능
}

public class GameStarter : NetworkBehaviour, IPlayerJoined
{
    public GameObject matchingUI;
    public Text playerInfoText;
    public Button playButton;
    private IPlayerJoined _playerJoinedImplementation;
    public Image player1Image;
    public Image player2Image;
    public int playerCount = 0;
    public Sprite workerSprite;
    public Sprite youtuberSprite;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    public void PlayerJoined(PlayerRef player)
    {
        // 플레이어 정보 업데이트
        UpdatePlayerInfo();
        
        // 현재 플레이어 수 확인
        if (Runner.ActivePlayers.Count() > 2)
        {
            // 최대 플레이어 수 초과 시 룸에서 퇴장
            Runner.Disconnect(player);
            Debug.Log("플레이어 수가 초과하여 접속이 거부되었습니다.");
            return;
        }
        
        playerCount++;

        
        // 플레이어의 정보를 가져옵니다.
        PlayerData playerData = GetPlayerData(player);
        
        // 플레이어 정보를 로그로 출력합니다.
        Debug.Log($"플레이어가 들어왔습니다: {playerData.Name}, ID: {playerData.Id}");
        
        // 추가적인 초기화 작업 수행
        InitializePlayer(playerData);

        // 최대 2명일 경우 매칭 UI 제거
        if (Runner.ActivePlayers.Count() == 2)
        {
            matchingUI.SetActive(false);
        }
        
        if (player == Runner.LocalPlayer){}
    }

    private void UpdatePlayerInfo()
    {
        playerInfoText.text = "플레이어 수: " + Runner.ActivePlayers.Count() + "/2";
    }

    private void OnPlayButtonClicked()
    {
        // 모든 플레이어가 Ready인지 확인 후 게임 시작
        if (IsAllPlayersReady())
        {
            // 본 게임 로직 시작
            StartGame();
        }
        else
        {
            Debug.Log("모든 플레이어가 준비되지 않았습니다.");
        }
    }

    private bool IsAllPlayersReady()
    {
        // Ready 상태를 체크하는 로직을 구현해야 합니다.
        // 예: 각 플레이어가 Ready 상태를 갖는 변수를 두고 확인
        // 이 예시에서는 항상 true를 반환합니다.
        return true;
    }

    private void StartGame()
    {
        // 본 게임 로직을 실행하는 부분
        Debug.Log("게임 시작!");
        // 게임 시작 관련 코드 추가
    }
    
    
    private PlayerData GetPlayerData(PlayerRef player)
    {
        // 예시로 PlayerData 클래스를 사용하여 정보를 반환합니다.
        // 플레이어의 이름이나 ID를 설정하는 로직을 추가할 수 있습니다.
        return new PlayerData
        {
            Name = $"Player_{player.PlayerId}",
            Id = player.PlayerId
        };
    }

    private void InitializePlayer(PlayerData playerData)
    {
        // 플레이어 초기화 로직
        // 예: UI 업데이트, 게임 오브젝트 생성 등

        if (playerCount == 1)
        {
            if (playerData.Name == "Worker")
            {
                player1Image.sprite = workerSprite;
            }
            if (playerData.Name == "Youtuber")
            {
                player1Image.sprite = youtuberSprite;
            }
        }
        
        if (playerCount == 2)
        {
            if (playerData.Name == "Worker")
            {
                player1Image.sprite = workerSprite;
            }
            if (playerData.Name == "Youtuber")
            {
                player1Image.sprite = youtuberSprite;
            }
        }
    }
    
}