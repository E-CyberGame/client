using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class OnGroundState : BaseState
    {
        public OnGroundState(ActorStat stat, WrapBody body) : base(stat, body) { }
        
        public override void Jump()
        {
            _stat.jumpCount++;
        }

        public override void Down()
        {
            
        }


        public override void HorizontalMove(Vector2 Horizontal)
        {
        
        }

        public override void EnterState()
        {

        }

        public override void UpdateState()
        {

        }

        public override void FixedUpdateState()
        {

        }

        public override void ExitState()
        {

        }
    }
}