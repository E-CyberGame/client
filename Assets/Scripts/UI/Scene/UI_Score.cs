using TMPro;
using UnityEngine;

namespace UI.Scene
{
    public class UI_Score : UI_Scene
    {
        private TextMeshProUGUI _score;
        enum Texts
        {
            Score,
        }
        
        private void Start()
        {
            Init();
        }

        public override void Init()
        {
            base.Init();
            Bind<TextMeshProUGUI>(typeof(Texts));

            _score = GetText((int)Texts.Score);
        }

        public void UpdateScore(int Red, int Blue)
        {
            _score.text = $"<color=#DC143C>{Red}</color> : <color=#0000CD>{Blue}</color>";
        }
    }
}