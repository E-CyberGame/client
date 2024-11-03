using Actor.Buff;
using UnityEngine;

namespace Actor.Skill
{
    public class JumpAttack : ProjectileSkill
    {
        private BuffController _buff;

        public new void Awake()
        {
            base.Awake();
            _buff = GetComponent<BuffController>();
            _icon = Resources.Load<Sprite>("Skill/Icons/JumpAttack");
            _coolTime = 4f;
            projectileList.Add(Resources.Load<GameObject>("Skill/Projectiles/Electronic"));
        }
        //Activate에서 can use 막기
        public override void Activate()
        {
            if (_body.OnGround()) return;
            if (!_canUse) return;
            
            base.Activate();
            
            Vector3 primaryPosition = _stat.transform.position;
            _buff.AddBuff(new StatDurationBuff(_stat.Atk, 0, 0.1f), 15f);
            Projectile ball = Generate(0);
            ball.Init(_stat, primaryPosition, Vector3.zero, 4f);
        }
    }
}