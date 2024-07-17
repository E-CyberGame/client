using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using UnityEngine;
using DG.Tweening;

namespace Actor.Skill
{
    //Goal : Projectile을 만들어서 넣으면 스킬이 되도록!
    public class ProjectileSkill : ISkill
    {
        protected ActorStat _stat;
        protected WrapBody _body;
        protected Transform _player; //스킬을 실행시킨 플레이어

        //생성되지 않은 에셋으로의 발사체
        public List<GameObject> goList { get; protected set; } = new List<GameObject>();
        //생성된 발사체
        protected List<Projectile> projectileList  = new List<Projectile>();

        public ProjectileSkill(ActorStat stat, WrapBody body, Transform player, string projectilePath)
        {
            _stat = stat;
            _body = body;
            _player = player;
            goList.Add(Resources.Load<GameObject>(projectilePath));
        }
        
        //go가 비는 문제 발생. -> 그냥 없앨까도...
        public ProjectileSkill(ActorStat stat, WrapBody body, Transform player)
        {
            _stat = stat;
            _body = body;
            _player = player;
        }

        public virtual void Activate()
        {
            Generate();
            projectileList[0].Fire(); //여러번 실행 시 최초 이후로 Fire 안되는 문제 있음
        }

        public virtual void Generate()
        {
            projectileList.Add(Managers.Resources.Instantiate(goList[0], _player.position).GetComponent<Projectile>());
        }
    }
}

