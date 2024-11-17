using System.Collections;
using System.Collections.Generic;
using UI.Scene;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private UI_HUD _view;
    private UI_Result _result;
    private UI_Score _score;

    public void Awake()
    {
        _view = GetComponent<UI_HUD>();
        _result = GetComponent<UI_Result>();
        _score = GetComponent<UI_Score>();
    }

    public void Start()
    {
        RoomManager.Instance.AfterGameEnd += delegate
        {
            _view.SetPanel("END"); 
        };
        
        RoomManager.Instance.EnterPostGame += delegate
        {
            _result.PopResult(); 
        };

        RoomManager.Instance.ScoreChanged += delegate
        {
            _score.UpdateScore(RoomManager.Instance.RedTeamDead, RoomManager.Instance.BlueTeamDead);
        };
    }
}
