using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor.Skill
{
    public class BlueRotation : ProjectileSkill
    {
        public new void Awake()
        {
            base.Awake();
            _coolTime = 10f;
            _icon = Resources.Load<Sprite>("Skill/Icons/BlueRotation");
            projectileList.Add(Resources.Load<GameObject>("Skill/Projectiles/BlueRotation"));
        }

        public override void Activate()
        {
            if (!_body.OnGround()) return;
            if (!_canUse) return;
            base.Activate();
            Explode();
        }

        private void Explode()
        {
            Vector3 primaryPosition = _stat.transform.position;
            Vector3 primaryDirection = _body.currentDirectionX;
            
            Projectile field = Generate(0);
            field.Init(_stat, primaryDirection, primaryPosition, Vector3.zero, 5f, Vector3.right * 3f, 3f);
            field.Fire();
        }
    }
}