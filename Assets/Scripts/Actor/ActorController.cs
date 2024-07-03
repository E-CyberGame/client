using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Actor
{
    public class ActorController : MonoBehaviour
    {
        private ActorStat _stat;
        private ActorField _field;
        private StateMachine _stateMachine;
        private SkillController _skill;

        void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _field = GetComponent<ActorField>();
            _skill = GetComponent<SkillController>();
            _stateMachine = new StateMachine(_field, GetComponent<WrapBody>(), GetComponent<Animator>());
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
    }

}
