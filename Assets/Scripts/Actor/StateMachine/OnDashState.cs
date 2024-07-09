using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnDashState : BaseState
    {
        public override void EnterState()
        {
            _body.DashOn();
            _anim.changeAnimation(ActorAnim.Dashing);
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