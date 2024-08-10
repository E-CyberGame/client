using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor
{
    public abstract class BaseState
    {
        protected WrapBody _body;
        protected ActorAnimController _anim;
        protected StateMachine _stateMachine;

        public BaseState(WrapBody body, Animator animator, ActorAnimController animController, StateMachine stateMachine)
        {
            _body = body;
            _stateMachine = stateMachine;
            _anim = animController;
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
