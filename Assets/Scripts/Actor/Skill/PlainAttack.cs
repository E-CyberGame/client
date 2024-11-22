using UnityEngine;

namespace Actor.Skill
{
    public class PlainAttack : ProjectileSkill
    {
        public new void Awake()
        {
            base.Awake();
            _coolTime = 0.6f;
            projectileList.Add(Resources.Load<GameObject>("Skill/Projectiles/Fireball"));
        }
        
        public override void Activate()
        {
            if (!_canUse) return;
            base.Activate();
            
            Vector3 primaryPosition = _stat.transform.position;
            Vector3 primaryDirection = _body.currentDirectionX;
            Projectile ball = Generate(0);
            if (ball is null) return;
            ball.Init(_stat, primaryDirection, primaryPosition, new Vector3(1f, 0.7f, 0f), 1.2f, new Vector3(10f, 0f, 0f), 1f);
            ball.Fire();
        }
    }
}