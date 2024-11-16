namespace Actor.Skill
{
    public class RapidMovementSkill : PassiveSkill
    {
        public override void OnSkill()
        {
            if (HasStateAuthority)
            {
                _stat.SetCoolTimePercent *= (_skillLevel * 0.1f) + 1f;
            }
        }
    }
}