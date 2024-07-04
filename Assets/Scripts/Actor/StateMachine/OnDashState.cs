using System.Collections;
using System.Collections.Generic;
using Managers;
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
            yield return new WaitForSeconds(0.2f);
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