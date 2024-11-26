using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Data;

public class UI_MainRoom : UI_Popup
{

    [SerializeField] private TextMeshProUGUI _playername, _playerlevel, _playercrystal, _playergold;
    [SerializeField]
    private Image characterstanding;

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
        GetButton((int)Buttons.CharacterButton).gameObject.BindUIEvent(CharacterButtonClicked);
        //GetButton((int)Buttons.SpecialRaidButton).gameObject.BindUIEvent(SpecialRaidButtonClicked);
        //GetButton((int)Buttons.SettingButton).gameObject.BindUIEvent(SpecialRaidButtonClicked);

        _playername.text = PlayerInfo.Instance.info.name;
        _playerlevel.text = PlayerInfo.Instance.info.level.ToString();
        _playercrystal.text = PlayerInfo.Instance.info.crystal.ToString();
        _playergold.text = PlayerInfo.Instance.info.gold.ToString();
        characterstanding.sprite = Resources.Load<Sprite>("Arts/Character/card_" + PlayerInfo.Instance.info.character.ToString());
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
