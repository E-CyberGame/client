using System.Collections;
using System.Collections.Generic;
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
        skillSlotDict = new Dictionary<SkillSlot, ISkill>();
        skillSlotDict.Add(SkillSlot.slot1, new FireBallSkill(stat));
        skillSlotDict.Add(SkillSlot.slot2, new WaterBallSkill(stat));
    }

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
