using Actor.Skill;
using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting;
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

    //Fluid Stat : ���� �� �������� ��ȭ�� ���� ū ����
    [Networked] public float hp { get; set; }

    //Game Stat : Read > Write
    //get, buff ���� MaxHP ����ϰ�, set�� maxHP ����ϴ� ������� ����
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
    private bool isAlive = true;
    public Queue<Tuple<float, int>> GetDamage = new Queue<Tuple<float, int>>();

    private void InitStat()
    {
        maxHP = 2000;         // �ִ� HP
        atk = 10;            // ���ݷ�
        cri_percent = 20f;    // ġ��Ÿ Ȯ��
        cri_damage = 1.5f;   // ġ��Ÿ ���� ����
        hp = maxHP;          // ���� HP�� �ִ� HP�� �ʱ�ȭ

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

    
    public override void FixedUpdateNetwork()
    {
        if(GetDamage.Count > 0 && isAlive)
        {
            Attack(GetDamage.Peek().Item1);
            if (hp < 0)
            {
                isAlive = false;
                Debug.Log("��Ÿ: " + GetDamage.Peek().Item2);
                Runner.Despawn(gameObject.GetComponent<NetworkObject>());
            }
            GetDamage.Dequeue();
        }
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

    public void Hitted(float damage, int hitter)
    {
        if (damage > 0)
        {
            Debug.Log("���� Ÿ�� " + damage + "�� ����");
            GetDamage.Enqueue(Tuple.Create(damage, hitter));
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
