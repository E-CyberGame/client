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
    enum Buttons
    {
        BackButton
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.BackButton).gameObject.BindUIEvent(BackButtonClicked);

    }
    public void BackButtonClicked(PointerEventData eventData)
    {
        Debug.Log("BackButton Clicked");
        SceneManager.LoadScene("MainRoom");
    }
}
