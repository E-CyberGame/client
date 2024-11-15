using Actor.Skill;
using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Fusion.NetworkBehaviour;

public class BossBehaviour : NetworkBehaviour, IHitted
{
    private ChangeDetector _changeDetector;

    public Action HpStatChanged = null;
    public Action MaxHpStatChanged = null;
    public Action AtkStatChanged = null;
    public Action CriPercentStatChanged = null;
    public Action CriDamageStatChanged = null;

    //Fluid Stat : 게임 중 유동적인 변화가 가장 큰 스탯
    [Networked] public float hp { get; set; }

    //Game Stat : Read > Write
    //get, buff 등은 MaxHP 사용하고, set은 maxHP 사용하는 방식으로 ㄱㄱ
    public GameStat MaxHP;
    [Networked] public float maxHP { get; set; }

    public GameStat Atk;
    [Networked] public float atk { get; set; }

    public GameStat CriPercent;
    [Networked] public float cri_percent { get; set; }

    public GameStat CriDamage;
    [Networked] public float cri_damage { get; set; }

    System.Random random = new System.Random();

    [SerializeField] GameObject BossPrefab;
    [SerializeField] UI_BossStatus _view;

    private void InitStat()
    {
        maxHP = 2000;         // 최대 HP
        atk = 10;            // 공격력
        cri_percent = 20f;    // 치명타 확률
        cri_damage = 1.5f;   // 치명타 피해 배율
        hp = maxHP;          // 현재 HP를 최대 HP로 초기화

        MaxHP = new GameStat(maxHP);
        Atk = new GameStat(atk);
        CriPercent = new GameStat(cri_percent);
        CriDamage = new GameStat(cri_damage);
    }

    public override void Spawned()
    {
        _changeDetector = GetChangeDetector(ChangeDetector.Source.SimulationState);
        InitStat();

        HpStatChanged += delegate { _view.UpdateHp(maxHP, hp); };
    }

    public void Attack(float damage)
    {
        if (damage < 0) return;
        if (random.Next(1, 101) < cri_percent)
        {
            damage *= cri_damage;
        }
        hp -= damage;
    }

    public void Hitted(float damage)
    {
        if (damage > 0)
        {
            Debug.Log("보스 타격 " + damage + "의 피해");
            Attack(damage);
        }
    }

    public void Hitted(IBuff buff, float time)
    {

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
                case nameof(maxHP):
                    MaxHpStatChanged?.Invoke();
                    MaxHP.SetValue(maxHP);
                    break;
                case nameof(atk):
                    AtkStatChanged?.Invoke();
                    Atk.SetValue(atk);
                    break;
                case nameof(cri_percent):
                    CriPercentStatChanged?.Invoke();
                    CriPercent.SetValue(cri_percent);
                    break;
                case nameof(cri_damage):
                    CriDamageStatChanged?.Invoke();
                    CriDamage.SetValue(cri_damage);
                    break;
            }
        }
    }

}
