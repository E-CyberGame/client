using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : UI_Scene
{
    private Image _hpBar;
    enum Images
    {
        HpBar,
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Image>(typeof(Images));

        _hpBar = GetImage((int)Images.HpBar);
    }

    public void UpdateHp(float maxHp, float hp)
    {
        _hpBar.fillAmount = hp / maxHp;
    }
}
