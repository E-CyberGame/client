using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    protected float _value;

    public float Value
    {
        get
        {
            return _value;
        }
    }

    public Stat(float value)
    {
        _value = value;
    }
}
