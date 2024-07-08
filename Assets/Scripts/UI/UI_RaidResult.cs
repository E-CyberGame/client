using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UI_RaidResult : UI_Popup
{
    private int playernum = 5;
    public GameObject playerProfileBG;
    enum Buttons
    {
        NextButton
    }

    private void Start()
    {
        Init();
        //Raid Card를 스크롤 뷰에 추가
        for (int i = 0; i < playernum; i++)
        {
            GameObject raidObject = Resources.Load<GameObject>("Prefabs/PlayerResult");
            GameObject instance = PrefabUtility.InstantiatePrefab(raidObject) as GameObject;
            instance.transform.SetParent(playerProfileBG.transform);
            instance.transform.localScale = Vector3.one;
        }
    }

    public override void Init()
    {
        base.Init();
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.NextButton).gameObject.BindUIEvent(NextButtonClicked);

    }

    public void NextButtonClicked(PointerEventData eventData)
    {
        Debug.Log("NextButton Clicked");
        SceneManager.LoadScene("Raid_Reward");
    }
}
