using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using UnityEngine;
using DG.Tweening;

namespace Actor.Skill
{
    //Goal : Projectile을 만들어서 넣으면 스킬이 되도록!
    public class ProjectileSkill : MonoBehaviour, ISkill
    {
        private int skillId = 0;
        protected ActorStat _stat;
        protected WrapBody _body;
        protected Transform _player; //스킬을 실행시킨 플레이어

        //생성되지 않은 에셋으로의 발사체
        public List<GameObject> goList { get; protected set; } = new List<GameObject>(5);
        //생성된 발사체
        protected List<Projectile>[] projectileList = new List<Projectile>[100];

        public void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _body = GetComponent<WrapBody>();
            _player = GetComponent<Transform>();
            goList.Add(Resources.Load<GameObject>("TestPrefabs/Fireball"));
        }

        //추후 리팩토링용
        protected int GetSkillId()
        {
            skillId++;
            return skillId;
        }

        public virtual void Activate()
        {
            int id = GetSkillId();
            projectileList[id] = new List<Projectile>();
            Generate(id, 0);
            projectileList[id][0].Init(new Vector3(1f, 0.7f, 0f), 1.2f, new Vector3(10f, 0f, 0f));
            projectileList[id][0].Fire();
        }

        public virtual void Generate(int id, int index)
        {
            projectileList[id].Add(Managers.Resources
                .Instantiate(goList[index], _player.position)
                .GetComponent<Projectile>());
        }
    }
}

