using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnGroundState : BaseState
    {
        public override void Jump()
        {
            _body.Jump();
        }

        public override void Move(Vector2 directionX)
        {
            _body.Move(directionX);
        }

        public override void EnterState()
        {

        }

        public override void ExitState()
        {

        }
    }
}