using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//버프에 따라 변경될 수 있는 값
public class GameStat : Stat
{
    public float percent = 1;
    public int number = 0;

    public new float Value
    {
        get
        {
            return _value * percent + number;
        }
    }
    public GameStat(float value) : base(value){}
}
