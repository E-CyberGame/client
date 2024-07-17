using UnityEngine;

namespace Actor.Skill
{
    public class ChainFireBall : ProjectileSkill
    {
        public ChainFireBall(ActorStat stat, WrapBody body, Transform player, string projectilePath) : base(stat, body, player, projectilePath)
        {
        }

        public ChainFireBall(ActorStat stat, WrapBody body, Transform player) : base(stat, body, player)
        {
        }
        
        public virtual void Activate()
        {
            Generate();
            projectileList[0].Fire();
        }
        
        public new void Generate()
        {
            projectileList[0] = Managers.Resources
                .Instantiate(goList[0].gameObject, _player.position)
                .GetComponent<Projectile>();
        }
    }
}