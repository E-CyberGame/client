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
        _stat.maxHP *= 1.25f; // <<< ��� �� (������ ���� ����)
        _stat.atk *= 1.25f;
        //_stat.MaxHP.percent += 0.25f; <<< �� �۵� ���� (GameStat�� ����)
        //_stat.Atk.percent += 0.25f;
    }

    public void OffBuff()
    {
        _stat.maxHP /= 1.25f;
        _stat.atk /= 1.25f;
        //_stat.MaxHP.percent -= 0.25f;
        //_stat.Atk.percent -= 0.25f;
    }

}
