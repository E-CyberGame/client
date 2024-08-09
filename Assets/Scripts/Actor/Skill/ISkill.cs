using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using UnityEngine.UI;

public abstract class ISkill : NetworkBehaviour
{
    public Animator _anim;
    public Sprite _icon{ get; protected set; }
    public float _coolTime{ get; protected set; }
    public bool _canUse { get; private set; } = true;
    public abstract void Activate();

    //너무 결합도 높은가 싶음... 쿨타임 UI를 그냥 Action으로 옮기는 것도 괜찮을지도...
    protected IEnumerator CoolDown(float coolTime)
    {
        //_anim.speed = 1 / coolTime;
        _canUse = false;
        //_anim.Play("CoolTime");
        yield return new WaitForSeconds(coolTime);
        _canUse = true;
        //_anim.Play("New State");
    }
}
