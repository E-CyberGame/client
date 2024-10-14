using Fusion;
using UnityEngine;


namespace Actor.Skill
{
    public abstract class PassiveSkill : NetworkBehaviour
    {
        protected ActorStat _stat;
        protected int _skillLevel = 1;

        public void Awake()
        {
            _stat = GetComponent<ActorStat>();
        }

        public abstract void OnSkill();
    }
}