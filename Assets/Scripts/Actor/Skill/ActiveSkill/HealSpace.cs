using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor.Skill
{
    public class HealSpace : ProjectileSkill
    {
        public new void Awake()
        {
            base.Awake();
            _coolTime = 2f;
            _icon = Resources.Load<Sprite>("SkillIcon/HealField");
            projectileList.Add(Resources.Load<GameObject>("TestPrefabs/HealField"));
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
            Projectile field = Generate(0);
            field.Init(_stat, primaryPosition, Vector3.zero);
            yield return new WaitForSeconds(6f);
            field.DestroyObject();
        }
        
    }
}