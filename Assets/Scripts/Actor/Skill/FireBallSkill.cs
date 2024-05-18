using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkill : ISkill
{
    private ActorStat _stat;
    public FireBallSkill(ActorStat stat)
    {
        Init(stat);
    }
    
    public void Init(ActorStat stat)
    {
        _stat = stat;
    }

    public void Activate()
    {
        Debug.Log("파이어볼 발사~!");
    }
}
