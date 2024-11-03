using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnHitState : BaseState
    {
        public OnHitState(WrapBody body, Animator animator, ActorAnimController animController, StateMachine stateMachine)
            : base(body, animator, animController, stateMachine)
        {
        
        }
        public override void EnterState()
        {
            _body.directionX = Vector2.zero;
            _body.GravityOFF();
            _anim.ChangeAnimation(ActorAnim.Hit);
            CoroutineHelper.Instance.StartCoroutineHelper(EscapeHit());
        }

        public override void ExitState()
        {
            _body.GravityOn();
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