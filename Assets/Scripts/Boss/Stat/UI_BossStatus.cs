using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_BossStatus : UI_Scene
{
    public Image _hpBar;
    enum Images
    {
        BossHpBar,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));

        _hpBar = GetImage((int)Images.BossHpBar);
    }

    public void UpdateHp(float maxHp, float hp)
    {
        _hpBar.fillAmount = hp / maxHp;
    }
}
