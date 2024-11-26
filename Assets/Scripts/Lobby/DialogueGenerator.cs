using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueGenerator : MonoBehaviour
{
    [SerializeField, TextArea]
    private List<string> dialogue = new List<string>();
    [SerializeField] private float delay;
    [SerializeField] private TextMeshProUGUI panel;
    void Start()
    {
        StartCoroutine(DialogueParser());
    }

    IEnumerator DialogueParser()
    {
        foreach (string text in dialogue)
        {
            panel.text = text;
            yield return new WaitForSeconds(delay);
        }
    }

    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
