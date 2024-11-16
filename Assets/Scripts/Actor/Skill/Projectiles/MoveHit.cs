using System;
using DG.Tweening;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class MoveHit : Projectile
    {
        private NetworkTransform _transform;
        private bool isFiring = false;

        public override void Hit(IHitted target)
        {
            if (!HasStateAuthority) return;
            if (target == null) return;
            target.Hitted(_stat.GetAtk.Value * _damage);
            _animator.SetTrigger("isHitted");
        }

        public void Awake()
        {
            _transform = GetComponent<NetworkTransform>();
        }

        public override void FixedUpdateNetwork()
        {
            if (!HasStateAuthority) return;
            if (isFiring)
            {
                transform.position += (Vector3)(_distance * _startDirection) * Runner.DeltaTime;
            }
            _transform.transform.position = transform.position;
        }

        public override void Fire()
        {
            Vector3 currentPosition = transform.position;
            if (!HasStateAuthority) return;
            isFiring = true;

            transform.DOMove(currentPosition + (Vector3)(_distance * _startDirection), _destroyDelay).OnComplete(() =>
            {
                isFiring = false;
                NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
                _animator.SetTrigger("isHitted");
            });
        }
    }
}