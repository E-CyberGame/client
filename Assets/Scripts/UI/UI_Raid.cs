using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UI_Raid : UI_Popup
{
    enum Buttons
    {
        NextButton
    }

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        //GetButton((int)Buttons.NextButton).gameObject.BindUIEvent(NextButtonClicked);

    }
    public void NextButtonClicked(PointerEventData eventData)
    {
        Debug.Log("NextButton Clicked");
        SceneManager.LoadScene("Raid_Result");
    }
}
