using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_HUD : UI_Scene
{
    //두개 합칠까 말까...
    private TextMeshProUGUI _middlePanel;
    private Animator _middleAnimator;
    [SerializeField] private GameObject _bossAlert;
    
    enum Images
    {
        MiddlePanel,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(Images));

        _middlePanel = GetText((int)Images.MiddlePanel);
        _middleAnimator = _middlePanel.gameObject.GetComponent<Animator>();

        StartCoroutine(BossAlarm());
    }
    
    public void StartGame()
    {
        _middlePanel.text = "Start";
        _middleAnimator.Play("StartAnimation");
    }

    IEnumerator BossAlarm()
    {
        yield return new WaitForSeconds(15.0f);
        _bossAlert.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        _bossAlert.SetActive(false);
    }

    public void SetPanel(string panelText)
    {
        _middlePanel.text = panelText;
        _middleAnimator.Play("StartAnimation", 0, 0f);
    }
}
