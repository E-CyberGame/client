using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Actor.Skill
{
    //Goal : Projectile을 만들어서 넣으면 스킬이 되도록!
    public class ProjectileSkill : ISkill
    {
        private int skillId = 0;
        protected ActorStat _stat;
        protected WrapBody _body;
        protected Transform _player; //스킬을 실행시킨 플레이어
        protected ActorController _actorController;

        //생성되지 않은 에셋(Resources)으로의 발사체
        public List<GameObject> goList { get; protected set; } = new List<GameObject>(5);
        //생성된 발사체
        protected List<Projectile>[] projectileList = new List<Projectile>[100];

        public void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _body = GetComponent<WrapBody>();
            _player = GetComponent<Transform>();
            _actorController = GetComponent<ActorController>();
            goList.Add(Resources.Load<GameObject>("TestPrefabs/Fireball"));
        }

        //추후 리팩토링용
        protected int GetSkillId()
        {
            skillId++;
            return skillId;
        }

        public override void Activate()
        {
            if (!_canUse) return;
            StartCoroutine(CoolDown(_coolTime));
            _actorController._stateMachine.ChangeState(States.OnHitted);
        }

        public void Generate(int id, int index)
        {
            projectileList[id]?.Add(Managers.Resources
                .Instantiate(goList[index], _player.position)
                .GetComponent<Projectile>());
        }
    }
}

