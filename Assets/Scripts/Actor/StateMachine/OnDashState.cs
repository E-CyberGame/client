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
        }

        public override void ExitState()
        {
            _body.DashOff();
        }
    }
}