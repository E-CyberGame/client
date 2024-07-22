using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
    public IEnumerator StartBuff();
    public void OnBuff();
    public void OffBuff();
}
