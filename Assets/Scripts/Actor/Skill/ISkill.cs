using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    public void Init(ActorStat stat, WrapBody body); //없앨까
    public void Activate();
}
