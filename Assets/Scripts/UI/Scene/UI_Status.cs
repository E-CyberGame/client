using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Status : UI_Scene
{
    public Image _hpBar;
    public Image _RteamhpBar1;
    public Image _RteamhpBar2;
    public Image _RteamhpBar3;
    public Image _BteamhpBar1;
    public Image _BteamhpBar2;
    public Image _BteamhpBar3;

    enum Images
    {
        characterHead,
        HpBar,
        RTeam1HpBar,
        RTeam2HpBar,
        RTeam3HpBar,
        BTeam1HpBar,
        BTeam2HpBar,
        BTeam3HpBar,
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
        _RteamhpBar1 = GetImage((int)Images.RTeam1HpBar);
        _RteamhpBar2 = GetImage((int)Images.RTeam2HpBar);
        _RteamhpBar3 = GetImage((int)Images.RTeam3HpBar);
        _BteamhpBar1 = GetImage((int)Images.BTeam1HpBar);
        _BteamhpBar2 = GetImage((int)Images.BTeam2HpBar);
        _BteamhpBar3 = GetImage((int)Images.BTeam3HpBar);

    }

    public void UpdateHp(float maxHp, float hp)
    {
        _hpBar.fillAmount = hp / maxHp;
    }

    public void SetHPbar()
    {

    }

    public void SetHeadImage(Sprite headImage)
    {
        Debug.Log(GetImage((int)Images.characterHead) is null);
        GetImage((int)Images.characterHead).sprite = headImage;
    }
}
