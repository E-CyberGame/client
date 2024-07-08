using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    private LinkedList<IBuff> _buffList;

    public void AddBuff(IBuff buff)
    {
        _buffList.AddLast(buff);
        StartCoroutine(buff.StartBuff());
    }
}
