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
        Debug.Log(_stat.MaxHP.Value);
        yield return new WaitForSeconds(4f);
        Debug.Log(_stat.MaxHP.Value);
        OffBuff();
        Debug.Log(_stat.MaxHP.Value);
    }

    public void OnBuff()
    {
        _stat.MaxHP.percent += 0.1f;
        _stat.ATK.percent += 0.1f;
    }

    public void OffBuff()
    {
        _stat.MaxHP.percent -= 0.1f;
        _stat.ATK.percent -= 0.1f;
    }
}
