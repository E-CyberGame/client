using Actor;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
            _skill.skillSlotDict[SkillSlot.slot1]._anim = _uiSkillSlot.GetAnimator(SkillSlot.slot1);
        }

        public void TakeDamage(int damage)
        {
            
        }

        public void UpdateSkillSlot()
        {
            Debug.Log(_skill.skillSlotDict[SkillSlot.slot1]._icon);
            _uiSkillSlot.SetSkillImage(SkillSlot.slot1, _skill.skillSlotDict[SkillSlot.slot1]._icon);
        }
    }
}