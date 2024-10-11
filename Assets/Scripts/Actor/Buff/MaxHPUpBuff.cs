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
    public IEnumerator StartBuff()
    {
        OnBuff();
        yield return new WaitForSeconds(4f);
        OffBuff();
    }

    public void OnBuff()
    {
        _stat.MaxHP.percent += 0.1f;
        _stat.Atk.percent += 0.1f;
    }

    public void OffBuff()
    {
        _stat.MaxHP.percent -= 0.1f;
        _stat.Atk.percent -= 0.1f;
    }
}
