using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HP, MP 등 게임 시 소모되는 값
public class FluidStat : Stat
{
    public Action StatChanged = null;
    public FluidStat(float value) : base(value){}

    public void SetStat(float value)
    {
        this._value = value;
        StatChanged?.Invoke();
    }
}
