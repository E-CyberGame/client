using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_CharacterManaging : UI_Popup
{
    private int spend_crystal;
    private int poll_rate = 99;
    private GameObject pollutionPopup;
    [SerializeField] private TextMeshProUGUI cost_text;
    [SerializeField] private TextMeshProUGUI after_poll;
    [SerializeField] private TextMeshProUGUI pollusion;
    enum Buttons
    {
        BackButton,
        /*
        Character1,
        Character2,
        Character3,
        Character4,
        */
        Skill1, Skill2, Skill3, Skill4,
        PollutionClearButton,
        PollutionPopupCancle, PollutionPopupAccept,
        Plus10Button, Minus10Button, Plus100Button,
    }

    private void Start()
    {
        pollutionPopup = GameObject.Find("PollutionPopup");
        Init();
        pollutionPopup.SetActive(false);
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.BackButton).gameObject.BindUIEvent(BackButtonClicked);
        //GetButton((int)Buttons.Character1).gameObject.BindUIEvent(CharacterButtonClicked);
        //GetButton((int)Buttons.Character2).gameObject.BindUIEvent(CharacterButtonClicked);
        //GetButton((int)Buttons.Character3).gameObject.BindUIEvent(CharacterButtonClicked);
        //GetButton((int)Buttons.Character4).gameObject.BindUIEvent(CharacterButtonClicked);
        GetButton((int)Buttons.Skill1).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Skill2).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Skill3).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Skill4).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.PollutionClearButton).gameObject.BindUIEvent(PollutionClearButtonClicked);
        GetButton((int)Buttons.PollutionPopupCancle).gameObject.BindUIEvent(PollutionPopupCancleClicked);
        GetButton((int)Buttons.PollutionPopupAccept).gameObject.BindUIEvent(PollutionPopupAcceptClicked);
        GetButton((int)Buttons.Plus10Button).gameObject.BindUIEvent(AddCrystal10);
        GetButton((int)Buttons.Minus10Button).gameObject.BindUIEvent(ReduceCrystal10);
        GetButton((int)Buttons.Plus100Button).gameObject.BindUIEvent(AddCrystal100);

    }
    public void BackButtonClicked(PointerEventData eventData)
    {
        Debug.Log("BackButton Clicked");
        SceneManager.LoadScene("MainRoom");
    }
    public void CharacterButtonClicked(PointerEventData eventData)
    {
        Debug.Log("CharacterButton Clicked");
    }
    public void SkillButtonClicked(PointerEventData eventData)
    {
        Debug.Log("SkillButton Clicked");
        SceneManager.LoadScene("SkillManaging");
    }
    public void PollutionClearButtonClicked(PointerEventData eventData)
    {
        Debug.Log("PollutionClearButton Clicked");
        pollutionPopup.SetActive(true);
    }
    public void PollutionPopupCancleClicked(PointerEventData eventData)
    {
        Debug.Log("PollutionPopupCancle Clicked");
        pollutionPopup.SetActive(false);
    }
    public void PollutionPopupAcceptClicked(PointerEventData eventData)
    {
        Debug.Log("PollutionPopupAccept Clicked");
        pollusion.text = poll_rate.ToString() + "%";
        pollutionPopup.SetActive(false);
    }
    public void AddCrystal10(PointerEventData eventData)
    {
        if (poll_rate - 1 <= 0) return;
        spend_crystal += 10;
        poll_rate -= 1;
        cost_text.text = spend_crystal.ToString();
        after_poll.text = poll_rate.ToString() + "%";
    }
    public void AddCrystal100(PointerEventData eventData)
    {
        if (poll_rate - 10 <= 0) return;
        spend_crystal += 100;
        poll_rate -= 10;
        cost_text.text = spend_crystal.ToString();
        after_poll.text = poll_rate.ToString() + "%";
    }
    public void ReduceCrystal10(PointerEventData eventData)
    {
        if (spend_crystal <= 0) return;
        spend_crystal -= 10;
        poll_rate += 1;
        cost_text.text = spend_crystal.ToString();
        after_poll.text = poll_rate.ToString() + "%";
    }
}
