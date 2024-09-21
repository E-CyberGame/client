using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.UI;

//Presenter을 RPC 동기화로 빼고 나머지를 그냥 냅두기 vs Model과 View만 동기화시키기
public class LobbyPresenter : MonoBehaviour
{
    private MatchingSetup model;
    public PVPSettingPanel settingView;
    public PVPJoinSetting joinView;
    public void Awake()
    {
        model = GetComponent<MatchingSetup>();
    }

    public void Start()
    {
        joinView.ClickCodeEnter(delegate {CodeEnter(joinView.GetCode());});
        joinView.ClickRandomEnter(RandomEnter);
    }

    //룸 세팅 후 룸에 참여
    public void StartRoom()
    {
        model.SetPVPData(settingView.GetGameData());
        model.StartPVPGame(settingView.GetGameData());
    }

    private void CodeEnter(string roomCode)
    {
        model.JoinPVPGame(roomCode);
    }

    private void RandomEnter()
    {
        model.JoinPVPGame();
    }
}
