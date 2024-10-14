using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
    public IEnumerator StartBuff(float time)
    {
        OnBuff();
        yield return new WaitForSeconds(time);
        OffBuff();
    }
    public void OnBuff();
    public void OffBuff();
}
