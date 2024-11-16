using UnityEngine;

namespace Actor.Skill
{
    public class StaticHit : Projectile
    {
        public float atkPercent = 1f;
        public override void Fire()
        {
            
        }

        public override void Hit(IHitted target)
        {
            if (!HasStateAuthority) return;
            if (target == null) return;
            target.Hitted(_stat.GetAtk.Value * atkPercent);
        }
    }
}