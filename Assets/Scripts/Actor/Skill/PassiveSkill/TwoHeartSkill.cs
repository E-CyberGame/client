using Fusion;
using UnityEngine;

namespace Actor.Skill
{
    public class TwoHeartSkill : PassiveSkill
    {
        public override void OnSkill()
        {
            if (HasStateAuthority)
            {
                _stat.maxHP *= (_skillLevel * 0.1f) + 1f;
            }
        }
    }
}