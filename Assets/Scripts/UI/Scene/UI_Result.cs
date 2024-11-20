using System;
using Fusion;
using TMPro;
//using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene
{
    public class UI_Result : UI_Scene
    {
        //두개 합칠까 말까...
        private GameObject _resultPanel;
        private Button _returnButton;

        enum Panel
        {
            ResultPanel,
        }

        enum Buttons
        {
            ReturnButton,
        }

        enum Texts
        {
            WinnerText,
            ScoreText,
        }

        private void Start()
        {
            Init();
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (_resultPanel is null) return;
            GetText((int)Texts.ScoreText).text 
                = $"<color=#DC143C>{RoomManager.Instance.BlueTeamDead}</color> : <color=#0000CD>{RoomManager.Instance.RedTeamDead}</color>";

            //이거 책임 RoomManager로 옮기기
            if (RoomManager.Instance.BlueTeamDead > RoomManager.Instance.RedTeamDead)
                GetText((int)Texts.WinnerText).text = "Blue Team Wins!";
            else GetText((int)Texts.WinnerText).text = "Red Team Wins!";
        }

        public override void Init()
        {
            base.Init();

            Bind<GameObject>(typeof(Panel));
            Bind<Button>(typeof(Buttons));
            Bind<TextMeshProUGUI>(typeof(Texts));

            _resultPanel = GetObject((int)Panel.ResultPanel);
            _returnButton = GetButton((int)Buttons.ReturnButton);
            
            _returnButton.onClick.AddListener(ReturnMenu);
        }

        public void PopResult()
        {
            _resultPanel.SetActive(true);
        }

        private void ReturnMenu()
        {
            RoomManager.Instance.ExitRoom();
        }
    }
}