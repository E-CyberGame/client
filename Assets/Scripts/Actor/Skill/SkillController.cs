using System;
using System.Collections;
using System.Collections.Generic;
using Actor.Skill;
using Fusion;
using UnityEditor;
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
    public List<PassiveSkill> PassiveSkills;
    public ISkill PlainSkill;
    
    void Awake()
    {
        PlainSkill = GetComponent<PlainAttack>();
        skillSlotInit();
        PassiveSkillinit();
    }

    public override void Spawned()
    {
        RoomManager.Instance.BeforeGameStart -= OnPassiveSkills;
        RoomManager.Instance.BeforeGameStart += OnPassiveSkills;
    }

    private void OnPassiveSkills()
    {
        foreach (var skill in PassiveSkills)
        {
            skill.OnSkill();
        }
    }

    //이거 봐서 가능하면... 그냥 끌어오기로 바꾸기... 그냥 component로 찾아서... 하는 걸로...
    public void PassiveSkillinit()
    {
        PassiveSkills.Add(gameObject.GetComponent<TwoHeartSkill>());
        PassiveSkills.Add(gameObject.GetComponent<RapidMovementSkill>());
    }
    
    //Network Behaviour은 스폰 전에 부착해야 함.
    //만약 스킬 설정 때문에 뭐... 어케 해야 하면 새로 오브젝트 파서 게임 시작할 때 생성
    public void skillSlotInit()
    {
        ISkill[] skills = gameObject.GetComponents<ISkill>();
        skillSlotDict = new Dictionary<SkillSlot, ISkill>();

        int index = 1; //PlainAttack 제외
        foreach(SkillSlot slot in Enum.GetValues(typeof(SkillSlot)))
        {
            if(index < skills.Length) skillSlotDict.Add(slot, skills[index]);
            index++;
        }
    }

    public void UseSkill(SkillSlot slot)
    {
        if (!HasStateAuthority) return;
        skillSlotDict[slot]?.Activate();
    }

    public void PlainAttack()
    {
        if (!HasStateAuthority) return;
        PlainSkill.Activate();
    }
}
