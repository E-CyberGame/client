using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public static ScriptManager Instance { get; private set; }

    /*
    public Putter playerControllerPrefab;
    public PlayerScoreboardUI playerScoreUI;
    public ScoreItem scoreItem;
    public PlayerSessionItemUI playerSessionItemUI;
    public WorldNickname worldNicknamePrefab;
    public GameObject splashEffect;

    public Level[] levels;
    */

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
