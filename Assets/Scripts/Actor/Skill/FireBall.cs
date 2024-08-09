using System;
using DG.Tweening;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class FireBall : Projectile, IHit
    {
        private NetworkTransform _transform;
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
            Runner.Despawn(gameObject.GetComponent<NetworkObject>());
        }

        public void Awake()
        {
            _transform = GetComponent<NetworkTransform>();
        }

        public override void FixedUpdateNetwork()
        {
            _transform.transform.position = transform.position;
        }

        public override void Fire()
        {
            Vector3 currentPosition = transform.position;
            if (!HasStateAuthority) return;
            
            Debug.Log("발사가되고는있니?");

            transform.DOLocalMove(currentPosition + (Vector3)(_distance * _body.currentDirectionX), 1f).OnComplete(() =>
            {
                NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
                if (networkObject is not null && Runner is not null)
                    Runner.Despawn(networkObject);
                else Debug.Log("삭제가 이루어지지 않음");
            });
        }
    }
}