using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor.Skill
{
    public class TripleExplosion : ProjectileSkill
    {
        [SerializeField] private List<Vector3> explodePosition;

        public new void Awake()
        {
            base.Awake();
            _coolTime = 2f;
            _icon = Resources.Load<Sprite>("Skill/Icons/TripleExplosion");
            projectileList.Add(Resources.Load<GameObject>("Skill/Projectiles/Explosion"));
        }

        public override void Activate()
        {
            if (!_canUse) return;
            base.Activate();
            StartCoroutine(Explode());
        }

        private IEnumerator Explode()
        {
            Vector3 primaryPosition = _stat.transform.position;

            List<Projectile> balls = new List<Projectile>();
            
            for (int i = 0; i < explodePosition.Count; i++)
            { 
                Projectile ball = Generate(0);
                if (ball is null) continue;
                ball.Init(_stat, primaryPosition, explodePosition[i], 1.5f);
                balls.Add(ball);
                yield return new WaitForSeconds(0.2f);
            }

            foreach (var ball in balls)
            {
                ball._animator.SetTrigger("isHitted");
            }
        }
    }
}