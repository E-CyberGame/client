using UnityEngine;

namespace Actor.Skill
{
    public class StaticHit : Projectile
    {
        public override void Fire()
        {
            
        }

        public override void Hit(IHitted target)
        {
            if (!HasStateAuthority) return;
            if (target == null) return;
            target.Hitted(_stat.atk);
        }
    }
}