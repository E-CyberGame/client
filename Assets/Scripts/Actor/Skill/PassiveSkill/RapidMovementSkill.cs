namespace Actor.Skill
{
    public class RapidMovementSkill : PassiveSkill
    {
        public override void OnSkill()
        {
            if (HasStateAuthority)
            {
                _stat.coolTimePercent *= (_skillLevel * 0.1f) + 1f;
            }
        }
    }
}