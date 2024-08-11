using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputButton
{
    Ready,
}


public struct NetInput : INetworkInput
{
    public NetworkButtons Buttons;
    public Vector2 Direction;
}
