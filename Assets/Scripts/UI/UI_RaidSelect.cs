using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UI_RaidSelect : UI_Popup
{
    //*****************************
    private int raidnum = 6;
    public ScrollRect scrollRect;
    //*****************************

    enum Buttons
    {
        BackButton
    }

    private void Awake()
    {
    }

    private void Start()
    {
        Init();

        //Raid Card를 스크롤 뷰에 추가
        for (int i = 0; i < raidnum; i++)
        {
            GameObject raidObject = Resources.Load<GameObject>("Prefabs/RaidCard");
            GameObject instance = PrefabUtility.InstantiatePrefab(raidObject) as GameObject;
            instance.BindUIEvent(NextButtonClicked);
            instance.transform.SetParent(scrollRect.content);
            instance.transform.localScale = Vector3.one;
        }
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
    public void NextButtonClicked(PointerEventData eventData)
    {
        Debug.Log("NextButton Clicked");
        SceneManager.LoadScene("Raid_Waiting");
    }
}
