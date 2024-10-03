using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MirrorSkill : MonoBehaviour, BSkill
{
    [SerializeField]
    GameObject mirror;


    public void Activate()
    {
        StartCoroutine(Mirror());
    }
    IEnumerator Mirror()
    {
        yield return new WaitForSeconds(1.0f);
        mirror.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        mirror.SetActive(false);
    }
}
