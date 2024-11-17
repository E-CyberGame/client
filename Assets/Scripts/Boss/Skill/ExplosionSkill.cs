using Actor.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSkill : MonoBehaviour, BSkill
{
    [SerializeField]
    GameObject explode;
    [SerializeField]
    Animator animator;


    public void Activate()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        animator.SetTrigger("boom");
        yield return new WaitForSeconds(0.5f);
        explode.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.8f);
        explode.GetComponent<CircleCollider2D>().enabled = false;
    }

}
