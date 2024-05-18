using System;
using System.Collections;
using System.Collections.Generic;
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

        void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _field = GetComponent<ActorField>();
            _stateMachine = new StateMachine(_field, GetComponent<WrapBody>());
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
        
        public void OnMove(InputValue input)
        {
            _stateMachine.Move(input.Get<Vector2>());
        }

        public void OnJump()
        {
            _stateMachine.Jump();
        }

        public void OnDown()
        {
            _stateMachine.Down();
        }
    }

}
