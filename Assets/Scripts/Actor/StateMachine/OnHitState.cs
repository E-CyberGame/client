using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnHitState : BaseState
    {
        public override void EnterState()
        {
            _anim.ChangeAnimation(ActorAnim.Hit);
            CoroutineHelper.Instance.StartCoroutineHelper(EscapeHit());
        }

        public override void ExitState()
        {
        }
        
        IEnumerator EscapeHit()
        {
            yield return new WaitForSeconds(1f);
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