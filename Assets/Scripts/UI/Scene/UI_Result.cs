using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene
{
    public class UI_Result : UI_Scene
    {
        //두개 합칠까 말까...
        public GameObject _resultPanel;
        public Button _returnButton;

        private void Start()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            
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