using System.Collections;
using UnityEngine;

    public class CoroutineHelper : MonoSingleton<CoroutineHelper>
    {
        public Coroutine StartCoroutineHelper(IEnumerator coroutine)
        { 
            return Instance.StartCoroutine(coroutine);
        }
        
        public void StopCoroutineHelper(Coroutine coroutine)
        { 
            Instance.StopCoroutine(coroutine);
        }
        
        public IEnumerator DelayHelper(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }
    }
