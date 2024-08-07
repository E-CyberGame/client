using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class FireBall : Projectile, IHit
    {
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
            target.Hitted(_stat.ATK.Value); 
            //Pierce();
            Managers.Resources.Destroy(gameObject);
        }
        public override void Fire()
        {
            Vector3 currentPosition = transform.position;
            transform.DOLocalMove(currentPosition + (Vector3)(_distance * _body.currentDirectionX), 1f);
            Managers.Resources.Destroy(gameObject, _destroyDelay);
        }
    }
}