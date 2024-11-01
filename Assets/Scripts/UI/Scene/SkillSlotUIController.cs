using Actor;
using UnityEngine;

namespace UI.Scene
{
    public class SkillSlotUIController : MonoBehaviour
    {
        private SkillController _skill;
        private UI_SkillSlot _uiSkillSlot;

        public void Awake()
        {
            _skill = GameObject.FindWithTag("Player").GetOrAddComponent<SkillController>();
            _uiSkillSlot = gameObject.GetComponent<UI_SkillSlot>();
        }

        public void Start()
        {
            UpdateSkillSlot();
            _skill.skillSlotDict[SkillSlot.slot1].SkillStart +=
                (f => _uiSkillSlot.StartCoolTimeAnimation((int)SkillSlot.slot1, f));
            _skill.skillSlotDict[SkillSlot.slot1].CoolTimeEnd +=
                () => _uiSkillSlot.EndCoolTimeAnimation((int)SkillSlot.slot1);
            _skill.skillSlotDict[SkillSlot.slot2].SkillStart +=
                (f => _uiSkillSlot.StartCoolTimeAnimation((int)SkillSlot.slot2, f));
            _skill.skillSlotDict[SkillSlot.slot2].CoolTimeEnd +=
                () => _uiSkillSlot.EndCoolTimeAnimation((int)SkillSlot.slot2);
        }

        public void TakeDamage(int damage)
        {
            
        }

        public void UpdateSkillSlot()
        {
            _uiSkillSlot.SetSkillImage(SkillSlot.slot1, _skill.skillSlotDict[SkillSlot.slot1]._icon);
            _uiSkillSlot.SetSkillImage(SkillSlot.slot2, _skill.skillSlotDict[SkillSlot.slot2]._icon);
        }
    }
}