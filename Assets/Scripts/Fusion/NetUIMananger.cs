using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NetUIMananger : MonoBehaviour
{
    public static NetUIMananger Singleton
    {
        get => _singleton;
        set
        {
            if (value == null)
                _singleton = null;
            else if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Destroy(value);
                Debug.LogError($"There should only ever be one instance of {nameof(NetUIMananger)}!");
            }
        }
    }
    private static NetUIMananger _singleton;

    [SerializeField] private TextMeshProUGUI _gameStateText;
    [SerializeField] private TextMeshProUGUI _instructionText;

    public void Awake()
    {
        Singleton = this;
    }

    private void OnDestroy()
    {
        if (Singleton == this)
            Singleton = null;
    }

    public void DidSetReady()
    {
        _instructionText.text = "Waiting for other players to be ready...";
    }

    public void SetWaitUI(GameState newState)
    {

        if (newState == GameState.Waiting)
        {
            _gameStateText.text = "Waiting to Start";
            _instructionText.text = "Press R when you're ready to begin";
        }

        _gameStateText.enabled = newState == GameState.Waiting;
        _instructionText.enabled = newState == GameState.Waiting;
    }

}
