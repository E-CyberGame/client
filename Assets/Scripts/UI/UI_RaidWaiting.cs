using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEditor;

public class UI_RaidWaiting : UI_Popup
{

    private int playernum = 0; // ���� ������ �÷��̾� �ο� ��
    public GameObject playerProfileBG;
    //*******************************
    private float[,] positions = { { -680.0f, 0.0f }, { -340.0f, 0.0f }, { 0.0f, 0.0f }, { 340.0f, 0.0f }, { 680.0f, 0.0f } };
    //*******************************
    
    enum Buttons
    {
        BackButton,
        NextButton,
        PlayerEnterButton
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
        GetButton((int)Buttons.NextButton).gameObject.BindUIEvent(NextButtonClicked);
        GetButton((int)Buttons.PlayerEnterButton).gameObject.BindUIEvent(PEButtonClicked);

    }
    public void BackButtonClicked(PointerEventData eventData)
    {
        Debug.Log("BackButton Clicked");
        SceneManager.LoadScene("Raid_Select");
    }
    public void NextButtonClicked(PointerEventData eventData)
    {
        Debug.Log("NextButton Clicked");
        SceneManager.LoadScene("Raid");
    }
    public void PEButtonClicked(PointerEventData eventData)
    {
        Debug.Log("PlayerEnterButton Clicked");
        PlayerEntered();
    }

    public void PlayerEntered()
    {
        // Instance ����
        GameObject playerObject = Resources.Load<GameObject>("Prefabs/PlayerWaiting");
        GameObject playerInstance = Instantiate(playerObject);

        // UI �̺�Ʈ bind
        playerInstance.BindUIEvent(NextButtonClicked);

        // position ��ġ ����
        playerInstance.transform.SetParent(playerProfileBG.transform);
        playerInstance.transform.localScale = Vector3.one;
        playerInstance.transform.localPosition = new Vector3(positions[playernum, 0], positions[playernum, 1],0);
        
        // player�� ���������Ƿ� playernum ����
        playernum++;
    }
}
