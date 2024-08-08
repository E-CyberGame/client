using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using DG.Tweening;
using ExitGames.Client.Photon.StructWrapping;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Actor
{
    public class ActorController : MonoBehaviour, IHitted
    {
        private ActorStat _stat;
        public StateMachine _stateMachine { get; private set; }
        private SkillController _skill;

        void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _skill = GetComponent<SkillController>();
            _stateMachine = new StateMachine(GetComponent<WrapBody>(), GetComponent<Animator>());
        }
        void Start()
        {
            /*if(CompareTag("Player"))
                _stat.HP.SetStat(50f);*/
        }

        void Update()
        {
            _stateMachine.UpdateState();
        }

        void FixedUpdate()
        {
            _stateMachine.FixedUpdateState();
        }

        #region Additional Input

        public void OnMove(InputValue input)
        {
            Vector2 direction = input.Get<Vector2>();
            Debug.Log(direction + tag);
            if (direction.x == 1.0f)
                transform.eulerAngles = Vector3.down * -180f;
            else if (direction.x == -1.0f) transform.eulerAngles = Vector3.zero;
            _stateMachine.Move(direction);
        }

        public void OnJump()
        {
            _stateMachine.Jump();
        }

        public void OnDown()
        {
            _stateMachine.Down();
        }

        public void OnDash()
        {
            _stateMachine.Dash();
        }

        #endregion

        public void Hitted(float damage, IBuff buff = null)
        {
            Debug.Log($"{damage} 맞아부럿성...");
            _stat.HP.AddStat(-damage);
            _stateMachine.ChangeState(States.OnHitted);
        }
    }

}
