using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Actor{
    
public class OnAirState : BaseState
{
    public override void Jump()
    {
        if (_field.MaxJumpCount <= _body.jumpCount)
            return;
        _body.Jump();
        _anim.changeAnimation(ActorAnim.Jumping);
    }

    public override void Down()
    {
        _body.Down();
        _anim.changeAnimation(ActorAnim.Falling);
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
        if(_anim.CurrentAnim == ActorAnim.Jumping)
            _anim.changeAnimation(ActorAnim.Idle);
    }
}
}
