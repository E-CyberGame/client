using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Fusion;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class ISkill : NetworkBehaviour
{
    protected ActorStat _stat;
    //UI 애니메이션
    [CanBeNull] public Animator _anim;
    public Sprite _icon{ get; protected set; }
    public float _coolTime{ get; protected set; }
    [Networked] public bool _canUse { get; set; } = true;
    public Action<float> SkillStart = null;
    public Action CoolTimeEnd = null;
    public abstract void Activate();

    //너무 결합도 높은가 싶음... ㅋㅋ ㅠ
    protected IEnumerator CoolDown(float coolTime)
    {
        //_anim이 null일 수 있고, 이건 확실히... 다른 쪽으로 넘기는 게 맞음.
        float realCoolTime = coolTime * _stat.CoolTimePercent.Value;
        if(HasStateAuthority) _canUse = false;
        SkillStart?.Invoke(realCoolTime);
        yield return new WaitForSeconds(realCoolTime);
        if(HasStateAuthority) _canUse = true;
        CoolTimeEnd?.Invoke();
    }
}
