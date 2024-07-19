using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class FireBall : Projectile, IHit
    {
        public void Init (Vector3 startPoint, float destroyDelay, Vector3 distance)
        {
            base.Init(startPoint, destroyDelay, distance);
            startPoint = new Vector3(1f, 0.7f, 0f);
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Hit(other.GetComponent<IHitted>());
            }
        }

        public void Hit(IHitted target)
        {
            Debug.Log("때려버렷다");
            target.Hitted(); 
            Pierce();
        }
        public override void Fire()
        {
            Vector3 currentPosition = transform.position;
            transform.DOLocalMove(currentPosition + _distance, 1f);
            Managers.Resources.Destroy(gameObject, _destroyDelay);
        }
    }
}