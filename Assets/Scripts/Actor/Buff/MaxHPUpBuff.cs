using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHPUpBuff : IBuff
{
    private ActorStat _stat;
    public MaxHPUpBuff(ActorStat stat)
    {
        _stat = stat;
    }

    public void OnBuff()
    {
        _stat.GetMaxHP.percent += 0.1f;
        _stat.GetAtk.percent += 0.1f;
    }

    public void OffBuff()
    {
        _stat.GetMaxHP.percent -= 0.1f;
        _stat.GetAtk.percent -= 0.1f;
    }
}
