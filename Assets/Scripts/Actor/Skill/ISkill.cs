using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public abstract class ISkill : NetworkBehaviour
{
    //UI 애니메이션
    public Animator _anim;
    public Sprite _icon{ get; protected set; }
    public float _coolTime{ get; protected set; }
    [Networked] public bool _canUse { get; set; } = true;
    public abstract void Activate();

    //너무 결합도 높은가 싶음... 쿨타임 UI를 그냥 Action으로 옮기는 것도 괜찮을지도...
    protected IEnumerator CoolDown(float coolTime)
    {
        if(HasStateAuthority) _canUse = false;
        _anim.speed = 1 / coolTime;
        _anim.Play("CoolTime");
        yield return new WaitForSeconds(coolTime);
        if(HasStateAuthority) _canUse = true;
        _anim.Play("New State");
    }
}
