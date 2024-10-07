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
    
    //Network Behaviour은 스폰 전에 부착해야 함.
    //만약 스킬 설정 때문에 뭐... 어케 해야 하면 새로 오브젝트 파서 게임 시작할 때 생성
    public void skillSlotInit()
    {
        skillSlotDict = new Dictionary<SkillSlot, ISkill>()
        {
            { SkillSlot.slot1, gameObject.GetComponent<ChainFireBall>() }
        };
    }

    public void UseSkill(SkillSlot slot)
    {
        if (!HasStateAuthority) return;
        Debug.Log("아니 실행은 여기서 했잖니");
        skillSlotDict[slot].Activate();
    }
}
