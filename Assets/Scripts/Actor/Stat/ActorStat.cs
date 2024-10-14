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
    
    //Fluid Stat : 게임 중 유동적인 변화가 가장 큰 스탯
    [Networked] public float hp { get; set; }
    [Networked] public float mp { get; set; }
    
    //Game Stat : Read > Write
    //get, buff 등은 MaxHP 사용하고, set은 maxHP 사용하는 방식으로 ㄱㄱ
    public GameStat MaxHP;
    [Networked] public float maxHP { get; set; }
    public GameStat MaxMP;
    [Networked] public float maxMP { get; set; }

    public GameStat Atk;
    [Networked] public float atk { get; set; }

    public GameStat Def;
    [Networked] public float def { get; set; }

    public GameStat CriPercent;
    [Networked] public float cri_percent { get; set; }

    public GameStat CriDamage;
    [Networked] public float cri_damage { get; set; }

    public GameStat Speed;
    [Networked] public float speed { get; set; }

    public GameStat CoolTimePercent;
    [Networked] public float coolTimePercent { get; set; }


    //캐릭터마다 다른 거. (움직임에 영향 주는 것.)
    [Header("Fixed Stat")]
    public float moveSpeed = 2f;
    public float jumpTime = 0.3f;
    public float downSpeed = 15f;
    public float dashSpeedRatio = 1.7f;
    public float dashTime = 0.3f;
    public int MaxJumpCount = 2;

    private void InitStat()
    {
        maxHP = 150;         // 최대 HP
        maxMP = 100;         // 최대 MP
        atk = 15;            // 공격력
        def = 5;             // 방어력
        cri_percent = 20;    // 치명타 확률
        cri_damage = 1.5f;   // 치명타 피해 배율
        speed = 3;           // 속도
        hp = maxHP;          // 현재 HP를 최대 HP로 초기화
        mp = maxMP;          // 현재 MP를 최대 MP로 초기화
        coolTimePercent = 1.0f;

        MaxHP = new GameStat(maxHP);
        MaxMP = new GameStat(maxMP);
        Atk = new GameStat(atk);
        Def = new GameStat(def);
        CriPercent = new GameStat(cri_percent);
        CriDamage = new GameStat(cri_damage);
        Speed = new GameStat(speed);
        CoolTimePercent = new GameStat(coolTimePercent);
    }

    #endregion

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
                    break;
                case nameof(mp):
                    MpStatChanged?.Invoke();
                    break;
                case nameof(maxHP):
                    MaxHpStatChanged?.Invoke();
                    MaxHP.SetValue(maxHP);
                    break;
                case nameof(maxMP):
                    MaxMpStatChanged?.Invoke();
                    MaxMP.SetValue(maxMP);
                    break;

                case nameof(atk):
                    AtkStatChanged?.Invoke();
                    Atk.SetValue(atk);
                    break;

                case nameof(def):
                    DefStatChanged?.Invoke();
                    Def.SetValue(def);
                    break;

                case nameof(cri_percent):
                    CriPercentStatChanged?.Invoke();
                    CriPercent.SetValue(cri_percent);
                    break;

                case nameof(cri_damage):
                    CriDamageStatChanged?.Invoke();
                    CriDamage.SetValue(cri_damage);
                    break;

                case nameof(speed):
                    SpeedStatChanged?.Invoke();
                    Speed.SetValue(speed);
                    break;
                
                case nameof(coolTimePercent):
                    CoolTimePercentStatChanged?.Invoke();
                    CoolTimePercent.SetValue(coolTimePercent);
                    break;
            }
            
        }
    }

}
