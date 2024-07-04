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

    [Header("Fluid Stat")]
    public float hp;
    public float mp;
    
    [Header("Game Stat")]
    public float maxHP;
    public float maxMP;
    public float atk;
    public float def;
    public float cri_percent;
    public float cri_damage;
    public float speed;
    
    [Header("Fixed Stat")]
    public float moveSpeed = 200f;
    public float jumpSpeed = 10f;
    public float jumpTime = 0.3f;
    public float downSpeed = 15f;
    public float dashSpeedRatio = 1.7f;
    public float dashSecond = 0.3f;
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
