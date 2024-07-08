using System.Collections;
using UnityEngine;

namespace Managers
{
    public class CoroutineHelper : Singleton<CoroutineHelper>
    {
        public Coroutine StartCoroutineHelper(IEnumerator coroutine)
        { 
            return Instance.StartCoroutine(coroutine);
        }
        
        public void StopCoroutineHelper(Coroutine coroutine)
        { 
            Instance.StopCoroutine(coroutine);
        }

    }
}