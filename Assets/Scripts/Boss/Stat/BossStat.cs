using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStat : MonoBehaviour
{
    /*
    public FluidStat HP { get; private set;} 
    public FixedStat MaxHP { get; private set; }
    public FixedStat ATK { get; private set; }
    public FixedStat DEF { get; private set; }
    public FixedStat MoveSpeed { get; private set; }*/


    public void Awake()
    {
        Init();
    }

    void Init ()
    {
        /*
        HP
        MaxHP
        ATK
        DEF
        MoveSpeed

        플레이어는 무브, 점프, 다운, 대시 스탯이 별개였는데
        보스도 스킬별로 그렇게 관리해야 할까?? 보스마다 결국 고유한 스킬을 사용한다면
        차라리 스킬 쪽에서 관리하는 것이 덜 복잡할지도.

        이외 보스마다 존재할 고유 스탯        
         */
    }

    public void Update ()
    {
        
    }
}
