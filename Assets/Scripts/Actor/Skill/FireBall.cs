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
        private bool isFiring = false;
        private Vector2 StartDirection;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != _playerLayer)
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
            Debug.Log(Runner is null);
            _transform = GetComponent<NetworkTransform>();
        }

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority) return;
            if (isFiring)
            {
                transform.position += (Vector3)(_distance * StartDirection) * Runner.DeltaTime;
            }
            _transform.transform.position = transform.position;
        }

        public override void Fire()
        {
            Vector3 currentPosition = transform.position;
            if (!HasStateAuthority) return;
            StartDirection = _body.currentDirectionX;
            isFiring = true;

            transform.DOMove(currentPosition + (Vector3)(_distance * _body.currentDirectionX), 1f).OnComplete(() =>
            {
                isFiring = false;
                NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
                if (networkObject is not null && Runner is not null)
                    Runner.Despawn(networkObject);
                else Debug.Log("삭제가 이루어지지 않음");
            });
        }
    }
}