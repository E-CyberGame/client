using System.Collections;
using UnityEngine;

namespace Managers
{
    public class CoroutineHelper : MonoBehaviour
    {
        private static CoroutineHelper _instance;

        public static CoroutineHelper Instance
        {
            get
            {
                if (_instance == null)
                    Init();
                return _instance;
            }
        }

        private void Awake()
        {
            //Safety Check
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        
        public Coroutine StartCoroutineHelper(IEnumerator coroutine)
        { 
            return Instance.StartCoroutine(coroutine);
        }
        
        public void StopCoroutineHelper(Coroutine coroutine)
        { 
            Instance.StopCoroutine(coroutine);
        }
            
        static bool Init()
        {
                if (_instance == null)
                {
                    GameObject obj = GameObject.Find("@CoroutineHelper");
                    if (obj == null)
                    {
                        obj = new GameObject { name = "@CoroutineHelper" };
                        obj.AddComponent<CoroutineHelper>();
                    }

                    DontDestroyOnLoad(obj);
                    _instance = obj.GetComponent<CoroutineHelper>();

                    return false;
                }

                return true;
        }

    }
}