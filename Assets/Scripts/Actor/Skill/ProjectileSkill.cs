using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using UnityEngine;

public class ProjectileSkill : ISkill
{
    private ActorStat _stat;
    private WrapBody _body;
    private Projectile _projectile;
    
    public ProjectileSkill(ActorStat stat, WrapBody body, Projectile projectile)
    {
        Init(stat, body);
        _projectile = projectile;
    }
    
    public void Init(ActorStat stat, WrapBody body)
    {
        _stat = stat;
        _body = body;
    }

    public void Activate()
    {
        _projectile.Generate();
        _projectile.Fire();
    }
}
