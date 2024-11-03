using System;
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
            foreach (SkillSlot slot in Enum.GetValues(typeof(SkillSlot)))
            {
                _skill.skillSlotDict[slot].SkillStart +=
                    (f => _uiSkillSlot.StartCoolTimeAnimation((int)slot, f));
                _skill.skillSlotDict[slot].CoolTimeEnd +=
                    () => _uiSkillSlot.EndCoolTimeAnimation((int)slot);
            }
        }

        public void TakeDamage(int damage)
        {
            
        }

        public void UpdateSkillSlot()
        {
            foreach (SkillSlot slot in Enum.GetValues(typeof(SkillSlot)))
            {
                _uiSkillSlot.SetSkillImage(slot, _skill.skillSlotDict[slot]._icon);
            }
        }
    }
}