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
        private StateMachine _stateMachine;

        void Awake()
        {
            _stat = GetComponent<ActorStat>();
            _stateMachine = new StateMachine(_stat, gameObject.transform, GetComponent<Rigidbody2D>());
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
            _stateMachine.OnMove(input.Get<Vector2>());
        }

        public void OnJump()
        {
            _stateMachine.OnJump();
        }

        public void OnDown()
        {
            _stateMachine.OnDown();
        }
    }

}
