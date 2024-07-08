using UnityEngine;

namespace Managers
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                Init();
                return _instance;
            }
            private set { _instance = value; }
        }

        protected virtual void Awake()
        {
            //Safety Check
            if(Init())
                Destroy(gameObject);
        }
        
        protected static bool Init()
        {
            if (_instance == null)
            {
                GameObject obj = GameObject.Find(typeof(T).ToString());
                if (obj == null)
                {
                    obj = new GameObject { name = typeof(T).ToString()};
                    obj.AddComponent<GameManager>();
                }

                DontDestroyOnLoad(obj);
                _instance = obj.GetComponent<T>();

                return false;
            }

            return true;
        }
    }

}