using System.Collections.Generic;
using UnityEngine;


namespace Actor.Skill
{
    public class BurnUp : ProjectileSkill
    {
        [SerializeField] private List<Vector3> explodePosition;

        public new void Awake()
        {
            base.Awake();
            _coolTime = 2f;
            _icon = Resources.Load<Sprite>("Skill/Icons/BurnUp");
            projectileList.Add(Resources.Load<GameObject>("Skill/Projectiles/Burn"));
        }

        public override void Activate()
        {
            if (!_canUse) return;
            base.Activate();
            Explode();
        }

        private void Explode()
        {
            Vector3 primaryPosition = _stat.transform.position;
            
            for (int i = 0; i < explodePosition.Count; i++)
            { 
                Projectile ball = Generate(0);
                if (ball is null) continue;
                ball.Init(_stat, primaryPosition, explodePosition[i]);
            }
        }
    }
}