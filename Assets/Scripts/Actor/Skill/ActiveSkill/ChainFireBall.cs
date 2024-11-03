using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actor.Buff;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Actor.Skill
{
    public class ChainFireBall : ProjectileSkill
    {
        private BuffController _buff;

        public new void Awake()
        {
            base.Awake();
            _buff = GetComponent<BuffController>();
            _icon = Resources.Load<Sprite>("Skill/Icons/ChainFireBall");
            _coolTime = 4f;
            projectileList.Add(Resources.Load<GameObject>("Skill/Projectiles/Fireball"));
        }
        //Activate에서 can use 막기
        public override void Activate()
        {
            if (!_canUse) return;
            base.Activate();
            StartCoroutine(Chain());
            _buff.AddBuff(new StatDurationBuff(_stat.MaxHP, 10, 0.1f), 10f);
        }
        
        IEnumerator Chain()
        {
            Vector3 primaryPosition = _stat.transform.position;
            Vector3 primaryDirection = _body.currentDirectionX;
            for (int i = 0; i < 3; i++)
            { 
                Projectile ball = Generate(0);
                if (ball is null) continue;
                ball.Init(_stat, primaryDirection, primaryPosition, new Vector3(1f, 0.7f, 0f), 1.2f, new Vector3(10f, 0f, 0f), 2f);
                ball.Fire();
                yield return new WaitForSeconds(0.7f);
            }
        }
    }
}