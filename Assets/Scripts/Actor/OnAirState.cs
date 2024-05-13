using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAirState : BaseState
{
    public OnAirState(ActorStat stat, WrapBody body) : base(stat, body) { }

        
    public override void Jump()
    {
        if (_stat.MaxJumpCount <= _stat.jumpCount)
            return;
        _stat.jumpCount++;
        _body.OnJump();
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
        _stat.jumpCount = 0;
    }
}
