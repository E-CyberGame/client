using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Actor{
    
public class OnAirState : BaseState
{
    
    public OnAirState(WrapBody body, Animator animator, ActorAnimController animController, StateMachine stateMachine)
        : base(body, animator, animController, stateMachine)
    {
        
    }
    
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
        Debug.Log(directionX + "OnAir");

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
