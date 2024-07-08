using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor
{
    public abstract class BaseState
    {
        protected static WrapBody _body;
        protected static ActorAnimController _anim;
        protected static StateMachine _stateMachine;

        public static void InitState(WrapBody body, Animator animator, StateMachine stateMachine)
        {
            _body = body;
            _stateMachine = stateMachine;
            _anim = new ActorAnimController(animator);
        }

        public virtual void Jump()
        {
        }

        public virtual void Down()
        {
        }
        
        public virtual void Dash()
        {
        }

        public virtual void Move(Vector2 directionX)
        {
        }

        public virtual void EnterState()
        {
        }

        public virtual void UpdateState()
        {
        }

        public virtual void FixedUpdateState()
        {
        }

        public virtual void ExitState()
        {
        }
    }
}
