using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ActorStat : MonoBehaviour
{
    /*public FluidStat HP { get; private set; }
    public FluidStat MP { get; private set; }

    public GameStat MaxHP { get; private set; }
    public GameStat MaxMP { get; private set; }
    public GameStat ATK { get; private set; }
    public GameStat DEF { get; private set; }
    public GameStat Critical_Percentage { get; private set; }
    public GameStat Critical_Damage { get; private set; }
    public GameStat Speed { get; private set; }

    //Fixed Stat 개선 필요. 반드시 Speed와 곱해서 나오는 결과인데 Wrap Body 에서 그냥 하드코딩 되어있음
    public FixedStat MoveSpeed { get; private set; }
    public FixedStat JumpSpeed { get; private set; }
    public FixedStat DownSpeed { get; private set; }
    public FixedStat DashSpeed { get; private set; }*/

    #region Inspector

    //게임 시 영구적인 증감이 일어나는 스탯
    [Header("Fluid Stat")] public FluidStat HP = new FluidStat(100);
    public float mp;

    //버프 적용을 받을 수 있는 스탯
    [Header("Game Stat")] public GameStat MaxHP = new GameStat(100);
    public GameStat ATK = new GameStat(10);
    public float maxHP;
    public float maxMP;
    public float atk;
    public float def;
    public float cri_percent;
    public float cri_damage;
    public float speed;
    
    //캐릭터마다 다른 거. (움직임에 영향 주는 것.)
    [Header("Fixed Stat")]
    public float moveSpeed = 2f;
    public float jumpTime = 0.3f;
    public float downSpeed = 15f;
    public float dashSpeedRatio = 1.7f;
    public float dashTime = 0.3f;
    public int MaxJumpCount = 2;

    #endregion

    public void Awake()
    {
        Init();
    }

    void Init()
    {
        /*HP = new FluidStat(hp);
        MP = new FluidStat(mp);
        MaxHP = new GameStat(maxHP);
        MaxMP = new GameStat(maxMP);
        ATK = new GameStat(atk);
        DEF = new GameStat(def);
        Critical_Percentage = new GameStat(cri_percent);
        Critical_Damage = new GameStat(cri_damage);
        Speed = new GameStat(speed);
        MoveSpeed = new FixedStat(moveSpeed);
        JumpSpeed = new FixedStat(jumpSpeed);
        DownSpeed = new FixedStat(downSpeed);
        DashSpeed = new FixedStat(dashSpeed);*/
    }

    public void Update()
    {
        /*if (moveSpeed != MoveSpeed.Value || jumpSpeed != JumpSpeed.Value || downSpeed != DownSpeed.Value)
        {
            Init();
        }*/
    }
}
