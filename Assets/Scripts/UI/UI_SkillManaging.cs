using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UI_SkillManaging : UI_Popup
{
    private GameObject skillPopup;
    private GameObject skillTrainPopup;

    enum Buttons
    {
        BackButton,
        SPSk1,
        SPSk2,
        SPSk3,
        Sk1, Sk2, Sk3, Sk4, Sk5, Sk6, Sk7, Sk8, Sk9,
        SkillPopupClose, SkillTrainButton,
        TrainCancelButton, TrainAcceptButton
    }

    private void Start()
    {
        skillPopup = GameObject.Find("SkillPopup");
        skillTrainPopup = GameObject.Find("SkillTrainPopup");
        Init();
        skillPopup.SetActive(false);
        skillTrainPopup.SetActive(false);
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.BackButton).gameObject.BindUIEvent(BackButtonClicked);
        GetButton((int)Buttons.SPSk1).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.SPSk2).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.SPSk3).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk1).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk2).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk3).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk4).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk5).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk6).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk7).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk8).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.Sk9).gameObject.BindUIEvent(SkillButtonClicked);
        GetButton((int)Buttons.SkillPopupClose).gameObject.BindUIEvent(PopupCloseButtonClicked);
        GetButton((int)Buttons.SkillTrainButton).gameObject.BindUIEvent(SkillTrainButtonClicked);
        GetButton((int)Buttons.TrainCancelButton).gameObject.BindUIEvent(TrainCancelButtonClicked);
        GetButton((int)Buttons.TrainAcceptButton).gameObject.BindUIEvent(TrainAcceptButtonClicked);
    }
    public void BackButtonClicked(PointerEventData eventData)
    {
        Debug.Log("BackButton Clicked");
        SceneManager.LoadScene("CharacterManaging");
    }
    public void SkillButtonClicked(PointerEventData eventData)
    {
        Debug.Log("SkillButton Clicked");
        skillPopup.SetActive(true);
    }
    public void PopupCloseButtonClicked(PointerEventData eventData)
    {
        Debug.Log("PopupCloseButton Clicked");
        skillPopup.SetActive(false);
    }
    public void SkillTrainButtonClicked(PointerEventData eventData)
    {
        Debug.Log("SkillTrainButton Clicked");
        skillTrainPopup.SetActive(true);
    }
    public void TrainCancelButtonClicked(PointerEventData eventData)
    {
        Debug.Log("TrainCancelButton Clicked");
        skillTrainPopup.SetActive(false);
    }
    public void TrainAcceptButtonClicked(PointerEventData eventData)
    {
        Debug.Log("TrainAcceptButton Clicked");
        skillTrainPopup.SetActive(false);
    }
}
