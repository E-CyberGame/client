using System.Collections.Generic;
using UnityEngine;


namespace Actor.Skill
{
    public class BurnUp : ProjectileSkill
    {
        [SerializeField] private List<Vector3> explodePosition;
        public override void Activate()
        {
            if (!_canUse) return;
            base.Activate();
            projectileList.Add(Resources.Load<GameObject>("TestPrefabs/Burn"));
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