using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnHittedState : BaseState
    {
        
        public OnHittedState(WrapBody body, Animator animator, ActorAnimController animController, StateMachine stateMachine)
            : base(body, animator, animController, stateMachine)
        {
        
        }
        public override void EnterState()
        {
            _body.StartHitted();
            _anim.ChangeAnimation(ActorAnim.Hitted);
            CoroutineHelper.Instance.StartCoroutineHelper(EscapeDash());
        }

        public override void ExitState()
        {
            _body.EndHitted();
        }
        
        IEnumerator EscapeDash()
        {
            yield return new WaitForSeconds(0.3f);
            if (_body.OnGround())
            {
                _stateMachine.ChangeState(States.OnGround);
            }
            else
            {
                _stateMachine.ChangeState(States.OnAir);
            }
        }
    }
}