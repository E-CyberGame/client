using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using UnityEngine;
using UnityEngine.InputSystem;

public enum SkillSlot
{
    slot1,
    slot2,
    slot3,
    slot4
}
public class SkillController : MonoBehaviour
{
    public Dictionary<SkillSlot, ISkill> skillSlotDict;

    void Awake()
    {
        skillSlotInit();
    }

    private void skillSlotInit()
    {
        ActorStat stat = GetComponent<ActorStat>();
        WrapBody body = GetComponent<WrapBody>();
        skillSlotDict = new Dictionary<SkillSlot, ISkill>();
        skillSlotDict.Add(SkillSlot.slot1, new ProjectileSkill(stat, body, transform, "TestPrefabs/FireBall"));
        //skillSlotDict.Add(SkillSlot.slot2, new WaterBallSkill(stat, body));
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
        skillSlotDict[slot].Activate();
    }
}
