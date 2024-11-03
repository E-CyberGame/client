using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IBuff
{
    public IEnumerator StartBuff(float time, UnityAction observer = null)
    {
        OnBuff();
        yield return new WaitForSeconds(time);
        OffBuff();
        observer?.Invoke();
    }
    public void OnBuff();
    public void OffBuff();
}
