using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.UI;

//Presenter을 RPC 동기화로 빼고 나머지를 그냥 냅두기 vs Model과 View만 동기화시키기
public class LobbyPresenter : MonoBehaviour
{
    private SessionSetup model;
    public PVPSettingPanel settingView;
    public PVPJoinSetting joinView;
    public void Awake()
    {
        model = GetComponent<SessionSetup>();
    }

    public void Start()
    {
        joinView.ClickCodeEnter(delegate {CodeEnter(joinView.GetCode());});
        joinView.ClickRandomEnter(RandomEnter);
    }

    //룸 세팅 후 룸에 참여
    public void StartRoom()
    {
        model.SetPVPData(settingView.GetSettingData());
        model.StartPVPGame(settingView.GetSettingData());
    }

    //룸 코드로 룸에 참여하는 코드.
    //만약 roomCode가 Null일 시 랜덤 참여
    public void CodeEnter(string roomCode = null)
    {
        model.JoinPVPGame(roomCode);
    }

    public void RandomEnter()
    {
        model.JoinPVPGame();
    }

    //룸 데이터 세팅(다른 요소들로 확장해도 되고...) -> RPC여도 될 듯
    //이게 연동되는 버전이 필요하고 연동 안되는 버전이 필요한데... (사유 : 최초 세팅/룸 내 세팅에 차이가 있음. )
    public void SetRoomData()
    {
        //model.SetRoomProperty(settingView.GetRoomProperty());
    }
}
