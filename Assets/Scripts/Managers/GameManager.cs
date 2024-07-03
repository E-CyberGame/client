using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { Init(); return _instance; } }
    
    private void Awake()
    {
        //Safety Check
        if(Init())
            Destroy(this.gameObject);
    }

    static bool Init()
    {
        if (_instance == null)
        {
            GameObject obj = GameObject.Find("@GameManager");
            if (obj == null)
            {
                obj = new GameObject { name = "@GameManager" };
                obj.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(obj);
            _instance = obj.GetComponent<GameManager>();

            return false;
        }

        return true;
    }
}
