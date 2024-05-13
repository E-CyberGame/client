using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState
{
    protected static ActorStat _stat;
    protected static WrapBody _body;

    protected BaseState() { }
    protected BaseState(ActorStat stat, WrapBody body)
    {
        InitState(stat, body);
    }

    public void InitState(ActorStat stat, WrapBody body)
    {
        _stat = stat;
        _body = body;
    }

    public abstract void Jump();
    public abstract void Down();
    public abstract void HorizontalMove(Vector2 Horizontal);

    public abstract void EnterState();

    public abstract void UpdateState();

    public abstract void FixedUpdateState();

    public abstract void ExitState();
}
