using UnityEngine;

public class WaterBallSkill : ISkill
    {
        private ActorStat _stat;
        private WrapBody _body;
        public WaterBallSkill(ActorStat stat, WrapBody body)
        {
            Init(stat, body);
        }
    
        public void Init(ActorStat stat, WrapBody body)
        {
            _stat = stat;
        }

        public override void Activate()
        {
            Debug.Log("워터볼 발사~!");
        }
    }
