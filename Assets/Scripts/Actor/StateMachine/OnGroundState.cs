using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor
{
    public class OnGroundState : BaseState
    {
        public override void Jump()
        {
            _body.Jump();
            _anim.changeAnimation(ActorAnim.Jumping);
        }

        public override void Move(Vector2 directionX)
        {
            _body.Move(directionX);
            CheckRunning(directionX);
        }

        public override void EnterState()
        {
            CheckRunning(_body.directionX);
            _body.ResetJumpCount();
        }

        public override void ExitState()
        {
        }

        private void CheckRunning(Vector2 directionX)
        {
            if(directionX.Equals(Vector2.zero))
                _anim.changeAnimation(ActorAnim.Idle);
            else _anim.changeAnimation(ActorAnim.Running);
        }
    }
}