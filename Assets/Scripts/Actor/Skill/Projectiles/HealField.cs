using System;
using Actor.Buff;
using UnityEngine;

namespace Actor.Skill
{
    public class HealField : Projectile
    {
        public override void Fire()
        {
            
        }
        
        public new void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                Hit(other.GetComponent<IHitted>());
            }
        }
        
        public override void Hit(IHitted target)
        {
            if (!HasStateAuthority) return;
            if (target == null) return;
            target.Hitted(-_stat.atk);
        }
    }
}