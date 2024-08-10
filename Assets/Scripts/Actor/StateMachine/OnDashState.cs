using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnDashState : BaseState
    {
        
        public OnDashState(WrapBody body, Animator animator, ActorAnimController animController, StateMachine stateMachine)
            : base(body, animator, animController, stateMachine)
        {
        
        }
        public override void EnterState()
        {
            _body.DashOn();
            _anim.ChangeAnimation(ActorAnim.Dash);
            CoroutineHelper.Instance.StartCoroutineHelper(EscapeDash());
        }

        public override void ExitState()
        {
            _body.DashOff();
        }
        
        IEnumerator EscapeDash()
        {
            yield return new WaitForSeconds(_body.GetDashTime());
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