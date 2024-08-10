using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class NoControlState : BaseState
    {
        public NoControlState(WrapBody body, Animator animator, ActorAnimController animController, StateMachine stateMachine)
            : base(body, animator, animController, stateMachine)
        {
        
        }
    }
}