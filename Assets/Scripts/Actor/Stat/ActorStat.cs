using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.Serialization;

public class ActorStat : NetworkBehaviour
{
    #region Inspector

    private ChangeDetector _changeDetector;

    public Action HpStatChanged = null;
    public Action MpStatChanged = null;
    public Action MaxHpStatChanged = null;
    public Action MaxMpStatChanged = null;
    public Action AtkStatChanged = null;
    public Action DefStatChanged = null;
    public Action CriPercentStatChanged = null;
    public Action CriDamageStatChanged = null;
    public Action SpeedStatChanged = null;
    public Action CoolTimePercentStatChanged = null;
    public Action DamagePercentStatChanged = null;

    //Fluid Stat : 게임 중 유동적인 변화가 가장 큰 스탯
    [Networked] public float hp { get; set; }
    [Networked] public float mp { get; set; }
    
    //Game Stat : Read > Write
    //get, buff 등은 MaxHP 사용하고, set은 maxHP 사용하는 방식으로 ㄱㄱ
    public GameStat GetMaxHP;
    [Networked] public float SetMaxHP { get; set; }
    public GameStat GetMaxMP;
    [Networked] public float SetMaxMP { get; set; }

    public GameStat GetAtk;
    [Networked] public float SetAtk { get; set; }

    public GameStat GetDef;
    [Networked] public float SetDef { get; set; }

    public GameStat GetCriPercent;
    [Networked] public float SetCriPercent { get; set; }

    public GameStat GetCriDamage;
    [Networked] public float SetCriDamage { get; set; }

    public GameStat GetSpeed;
    [Networked] public float SetSpeed { get; set; }

    public GameStat GetCoolTimePercent;
    [Networked] public float SetCoolTimePercent { get; set; }
    
    public GameStat GetDamagePercent;
    [Networked] public float SetDamagePercent { get; set; }


    //캐릭터마다 다른 거. (움직임에 영향 주는 것.)
    [Header("Fixed Stat")]
    public float moveSpeed = 2f;
    public float jumpTime = 0.3f;
    public float downSpeed = 15f;
    public float dashSpeedRatio = 1.7f;
    public float dashTime = 0.3f;
    public float gravity = 1f;
    public int MaxJumpCount = 2;

    private void InitStat()
    {
        SetMaxHP = 100;         // 최대 HP
        SetMaxMP = 100;         // 최대 MP
        SetAtk = 15;            // 공격력
        SetDef = 5;             // 방어력
        SetCriPercent = 20f;    // 치명타 확률
        SetCriDamage = 1.5f;   // 치명타 피해 배율
        SetSpeed = 3;           // 속도
        hp = SetMaxHP;          // 현재 HP를 최대 HP로 초기화
        mp = 0;         
        SetCoolTimePercent = 1.0f;
        SetDamagePercent = 1f;

        GetMaxHP = new GameStat(SetMaxHP);
        GetMaxMP = new GameStat(SetMaxMP);
        GetAtk = new GameStat(SetAtk);
        GetDef = new GameStat(SetDef);
        GetCriPercent = new GameStat(SetCriPercent);
        GetCriDamage = new GameStat(SetCriDamage);
        GetSpeed = new GameStat(SetSpeed);
        GetCoolTimePercent = new GameStat(SetCoolTimePercent);
        GetDamagePercent = new GameStat(SetDamagePercent);
    }

    #endregion
    
    System.Random random = new System.Random();
    public void Attack(float damage)
    {
        if (damage < 0) return;
        if (random.Next(1, 101) < SetCriPercent)
        {
            damage *= SetCriDamage;
        }
        hp -= damage * SetDamagePercent;
    }

    public void Heal(float healAmount)
    {
        if (healAmount < 0) return;
        hp += healAmount;
    }

    public override void Spawned()
    {
        _changeDetector = GetChangeDetector(ChangeDetector.Source.SimulationState);
        InitStat();
    }
    
    public override void Render()
    {
        foreach (var change in _changeDetector.DetectChanges(this))
        {
            switch (change)
            {
                case nameof(hp):
                    HpStatChanged?.Invoke();
                    if (hp <= 0)
                    {
                        RoomManager.Instance.RespawnPlayer(Runner.LocalPlayer);
                        hp = GetMaxHP.Value;
                    }
                    break;
                case nameof(mp):
                    MpStatChanged?.Invoke();
                    break;
                case nameof(SetMaxHP):
                    MaxHpStatChanged?.Invoke();
                    GetMaxHP.SetValue(SetMaxHP);
                    break;
                case nameof(SetMaxMP):
                    MaxMpStatChanged?.Invoke();
                    GetMaxMP.SetValue(SetMaxMP);
                    break;

                case nameof(SetAtk):
                    AtkStatChanged?.Invoke();
                    GetAtk.SetValue(SetAtk);
                    break;

                case nameof(SetDef):
                    DefStatChanged?.Invoke();
                    GetDef.SetValue(SetDef);
                    break;

                case nameof(SetCriPercent):
                    CriPercentStatChanged?.Invoke();
                    GetCriPercent.SetValue(SetCriPercent);
                    break;

                case nameof(SetCriDamage):
                    CriDamageStatChanged?.Invoke();
                    GetCriDamage.SetValue(SetCriDamage);
                    break;

                case nameof(SetSpeed):
                    SpeedStatChanged?.Invoke();
                    GetSpeed.SetValue(SetSpeed);
                    break;
                
                case nameof(SetCoolTimePercent):
                    CoolTimePercentStatChanged?.Invoke();
                    GetCoolTimePercent.SetValue(SetCoolTimePercent);
                    break;
                
                case nameof(SetDamagePercent):
                    DamagePercentStatChanged?.Invoke();
                    GetDamagePercent.SetValue(SetDamagePercent);
                    break;
            }
            
        }
    }

}
