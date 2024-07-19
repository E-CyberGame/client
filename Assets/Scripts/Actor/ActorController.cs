using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Actor
{
    public class ActorController : MonoBehaviour, IHitted
    {
        private ActorStat _stat;
        private StateMachine _stateMachine;
        private SkillController _skill;

        void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _skill = GetComponent<SkillController>();
            _stateMachine = new StateMachine(GetComponent<WrapBody>(), GetComponent<Animator>());
        }
        void Start()
        {
            
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
            Debug.Log(direction);
            if (direction.x == -1.0f)
                transform.eulerAngles = Vector3.down * -180f;
            else if (direction.x == 1.0f) transform.eulerAngles = Vector3.zero;
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

        public void Hitted()
        {
            Debug.Log("맞아부럿성...");
        }
    }

}
