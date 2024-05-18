using UnityEngine;

public class WaterBallSkill : ISkill
    {
        private ActorStat _stat;
        public WaterBallSkill(ActorStat stat)
        {
            Init(stat);
        }
    
        public void Init(ActorStat stat)
        {
            _stat = stat;
        }

        public void Activate()
        {
            Debug.Log("워터볼 발사~!");
        }
    }
