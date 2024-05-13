using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_MainRoom : UI_Popup
{
    enum Buttons
    {
        RaidButton,
        PVPButton,
        CharacterButton,
        ItemButton,
        SpecialRaidButton,
        SettingButton
    }
    
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.RaidButton).gameObject.BindUIEvent(RaidButtonClicked);
        GetButton((int)Buttons.PVPButton).gameObject.BindUIEvent(PVPButtonClicked);
        GetButton((int)Buttons.CharacterButton).gameObject.BindUIEvent(CharacterButtonClicked);
        GetButton((int)Buttons.ItemButton).gameObject.BindUIEvent(ItemButtonClicked);
        GetButton((int)Buttons.SpecialRaidButton).gameObject.BindUIEvent(SpecialRaidButtonClicked);
        //GetButton((int)Buttons.SettingButton).gameObject.BindUIEvent(SpecialRaidButtonClicked);

    }
    public void RaidButtonClicked(PointerEventData eventData)
    {
        Debug.Log("RaidButton Clicked");
        SceneManager.LoadScene("Raid_Select");
    }

    public void PVPButtonClicked(PointerEventData eventData)
    {
        Debug.Log("PVPButton Clicked");
        SceneManager.LoadScene("PVP");
    }

    public void CharacterButtonClicked(PointerEventData eventData)
    {
        Debug.Log("CharacterButton Clicked");
        SceneManager.LoadScene("CharacterManaging");
    }
    public void ItemButtonClicked(PointerEventData eventData)
    {
        Debug.Log("ItemButton Clicked");
        SceneManager.LoadScene("Item");
    }
    public void SpecialRaidButtonClicked(PointerEventData eventData)
    {
        Debug.Log("SpecialRaidButton Clicked");
        SceneManager.LoadScene("Raid_Select");
    }
}
