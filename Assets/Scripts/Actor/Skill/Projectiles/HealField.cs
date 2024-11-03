using System;
using System.Collections.Generic;
using Actor.Buff;
using UnityEngine;

namespace Actor.Skill
{
    public class HealField : Projectile
    {
        private List<string> _receivedPlayer = new List<string>();
        public override void Fire()
        {
            
        }
        
        public new void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == _playerLayer)
            {
                string playerName = other.gameObject.name;
                foreach(var player in _receivedPlayer)
                {
                    if (playerName == player)
                    {
                        return;
                    }
                }
                Hit(other.GetComponent<IHitted>());

                _receivedPlayer.Add(other.gameObject.name);
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