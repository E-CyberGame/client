using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAirState : BaseState
{

    public int jumpCount = 1;
    
    public override void Jump()
    {
        if (_field.MaxJumpCount <= jumpCount)
            return;
        jumpCount++;
        _body.Jump();
    }

    public override void Down()
    {
        _body.Down();
    }

    public override void Move(Vector2 directionX)
    {
        _body.Move(directionX);
    }

    public override void EnterState()
    {
        jumpCount = 1;
    }

    public override void ExitState()
    {
        
    }
}
