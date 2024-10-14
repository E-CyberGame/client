using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene
{
    public class UI_BuffList : UI_Scene
    {
        private GameObject _panel;
        private GameObject _buffPrefab;

        enum UIObject
        {
            Panel,
        }

        public void Start()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            Bind<GameObject>(typeof(UIObject));
            _buffPrefab = Managers.Resources.Load<GameObject>("UI/BuffIcon");
        }

        public void AddBuff()
        {
            
        }

        public void RemoveBuff()
        {
            
        }
    }
}