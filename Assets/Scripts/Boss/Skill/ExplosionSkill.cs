using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkill : MonoBehaviour, BSkill
{
    [SerializeField]
    GameObject explode;

    public void Activate()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(1.0f);
        explode.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        explode.SetActive(false);
    }
}
