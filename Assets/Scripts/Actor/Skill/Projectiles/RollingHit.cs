using System;
using System.Collections;
using DG.Tweening;
using Fusion;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class RollingHit : Projectile
    {
        private NetworkTransform _transform;
        private bool isFiring = false;

        public override void Hit(IHitted target)
        {
            if (!HasStateAuthority) return;
            if (target == null) return;
            target.Hitted(_stat.GetAtk.Value * _damage, _playerLayer);
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
            if (!HasStateAuthority) return;
            StartCoroutine(Roll());
        }

        IEnumerator Roll()
        {
            yield return new WaitForSeconds(2f);
            _distance = Vector3.right * 3f;
            isFiring = true;
            yield return new WaitForSeconds(_destroyDelay);
            DestroyObject();
        }
    }
}