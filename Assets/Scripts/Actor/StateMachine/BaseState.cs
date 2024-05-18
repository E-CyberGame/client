using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState
{
    protected static ActorField _field;
    protected static WrapBody _body;

    public static void InitState(ActorField field, WrapBody body)
    {
        _field = field;
        _body = body;
    }

    public virtual void Jump(){}
    public virtual void Down(){}
    public virtual void Move(Vector2 directionX){}

    public virtual void EnterState(){}

    public virtual void UpdateState(){}

    public virtual void FixedUpdateState(){}

    public virtual void ExitState(){}
}
