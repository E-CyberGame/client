using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public enum InputButton
{
    Jump,
    Down,
    Dash,
}

public enum SkillButton
{
    A,
    S,
    D,
    C
}

public struct PlayerNetworkInput : INetworkInput
{
    public NetworkButtons MoveButtons;
    public NetworkButtons SkillButtons;
    public Vector2 Direction;
}
