using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public enum SkillSlot
{
    slot1,
    slot2,
    slot3,
    slot4
}
public class SkillController : NetworkBehaviour
{
    public Dictionary<SkillSlot, ISkill> skillSlotDict;

    void Awake()
    {
        skillSlotInit();
    }

    private void skillSlotInit()
    {
        skillSlotDict = new Dictionary<SkillSlot, ISkill>()
        {
            { SkillSlot.slot1, gameObject.GetComponent<ChainFireBall>() }
        };
    }

    //인풋 다르게 받는 방법 있으니 개선할 것
    public void OnSkillSlot1()
    {
        UseSkill(SkillSlot.slot1);
    }
    public void OnSkillSlot2()
    {
        UseSkill(SkillSlot.slot2);
    }

    public void UseSkill(SkillSlot slot)
    {
        if (HasStateAuthority == false)
        {
            return;
        }
        skillSlotDict[slot].Activate();
    }
}
