using System.Collections;
using System.Collections.Generic;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PVPJoinSetting : MonoBehaviour
{
    [SerializeField]
    private Button RandomEnter;
    [SerializeField]
    private Button CodeEnter;
    [SerializeField]
    private TMP_InputField input;

    public string GetCode()
    {
        return input.text;
    }

    public void ClickCodeEnter(UnityAction action)
    {
        CodeEnter.onClick.AddListener(action);
    }

    public void ClickRandomEnter(UnityAction action)
    {
        RandomEnter.onClick.AddListener(action);
    }
}
