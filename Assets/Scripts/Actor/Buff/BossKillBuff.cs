using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKillBuff : IBuff
{
    private ActorStat _stat;
    public BossKillBuff(ActorStat stat)
    {
        _stat = stat;
    }
    public void OnBuff()
    {
        _stat.GetMaxHP.percent += 0.25f; 
        _stat.GetAtk.percent += 0.25f;
    }

    public void OffBuff()
    {
        _stat.GetMaxHP.percent -= 0.25f;
        _stat.GetAtk.percent -= 0.25f;
    }

}
