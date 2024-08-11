using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public TMP_InputField roomNameInputField;
    public Button createRoomButton;
    private NetworkRunner _runner;

    private void Start()
    {
        createRoomButton.onClick.AddListener(JoinRoom);
        _runner = gameObject.GetComponent<NetworkRunner>();
    }

    private void JoinRoom()
    {
        string roomName = roomNameInputField.text;

        if (string.IsNullOrWhiteSpace(roomName))
        {
            Debug.LogError("룸 이름을 입력해주세요.");
            return;
        }

        _runner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Shared,
            SessionName = roomName,
        });

        Debug.Log(roomName);
    }
    
}