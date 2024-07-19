using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Actor.Skill
{
    public class ChainFireBall : ProjectileSkill
    {
        private BuffController _buff;

        public void Awake()
        {
            base.Awake();
            _buff = GetComponent<BuffController>();
        }
        public override void Activate()
        {
            Debug.Log("Chain Fire Ball");
            int id = GetSkillId();
            projectileList[id] = new List<Projectile>();
            StartCoroutine(Chain(id));
            _buff.AddBuff(new MaxHPUpBuff(_stat));
        }
        
        public override void Generate(int id, int index)
        {
            projectileList[id]?.Add(Managers.Resources
                .Instantiate(goList[index].gameObject, _player.position)
                .GetComponent<Projectile>());
        }
        
        IEnumerator Chain(int id)
        {
            for (int i = 0; i < 3; i++)
            {
                Generate(id, 0);
                projectileList[id][i].Init(_stat, new Vector3(1f, 0.7f, 0f), 1.2f, new Vector3(10f, 0f, 0f));
                projectileList[id][i].Fire();
                yield return new WaitForSeconds(0.7f);
            }
        }
    }
}