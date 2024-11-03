using System;
using System.Collections.Generic;
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
            if (!HasStateAuthority) return;
            if (other.gameObject.layer == _playerLayer)
            {
                other.GetComponent<ActorStat>().damagePercent = 0.4f;
            }
        }
        
        public new void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                other.GetComponent<ActorStat>().damagePercent = 1f;
            }
        }
        
        public override void Hit(IHitted target)
        {
        }
    }
}