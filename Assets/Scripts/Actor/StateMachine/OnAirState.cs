using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Actor{
    
public class OnAirState : BaseState
{
    public override void Jump()
    {
        if (_body.CanJump())
            return;
        _body.Jump();
        _anim.ChangeAnimation(ActorAnim.Jumping);
    }

    public override void Down()
    {
        _body.Down();
        _anim.ChangeAnimation(ActorAnim.Down);
    }

    public override void Move(Vector2 directionX)
    {
        _body.Move(directionX);
    }

    public override void EnterState()
    {
    }
    
    public override void FixedUpdateState()
    {
        if (_body.OnGround())
        {
            _stateMachine.ChangeState(States.OnGround);
        }
    }

    public override void ExitState()
    {
        if(_anim.CurrentAnim == ActorAnim.Jumping)
            _anim.ChangeAnimation(ActorAnim.Idle);
    }
}
}
