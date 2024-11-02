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
    private string _name = "Test-Player", _level = "10", _crystal = "987654321", _gold = "123456789";

    [SerializeField] private TextMeshProUGUI _playername, _playerlevel, _playercrystal, _playergold; 

    enum Buttons
    {
        SoloButton,
        MultiButton,
        CharacterButton,
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

        GetButton((int)Buttons.SoloButton).gameObject.BindUIEvent(SoloButtonClicked);
        GetButton((int)Buttons.MultiButton).gameObject.BindUIEvent(MultiButtonClicked);
        //GetButton((int)Buttons.CharacterButton).gameObject.BindUIEvent(CharacterButtonClicked);
        //GetButton((int)Buttons.SpecialRaidButton).gameObject.BindUIEvent(SpecialRaidButtonClicked);
        //GetButton((int)Buttons.SettingButton).gameObject.BindUIEvent(SpecialRaidButtonClicked);

        _playername.text = _name;
        _playerlevel.text = _level;
        _playercrystal.text = _crystal;
        _playergold.text = _gold;

    }
    public void SoloButtonClicked(PointerEventData eventData)
    {
        //나중에 변경
        Debug.Log("SoloButton Clicked");
        SceneManager.LoadScene("Lobby");
    }

    public void MultiButtonClicked(PointerEventData eventData)
    {
        Debug.Log("MultiButton Clicked");
        SceneManager.LoadScene("Lobby");
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
