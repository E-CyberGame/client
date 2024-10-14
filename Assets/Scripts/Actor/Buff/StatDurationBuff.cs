using System.Collections;

namespace Actor.Buff
{
    //일정 시간 동안 GameStat의 값을 변경하는 버프
    public class StatDurationBuff : IBuff
    {
        private GameStat _gameStat;
        private int _number;
        private float _percent;

        public StatDurationBuff(GameStat gameStat, int number = 0, float percent = 0f)
        {
            _gameStat = gameStat;
            _number = number;
            _percent = percent;
        }
        
        public void OnBuff()
        {
            _gameStat.percent += _percent;
            _gameStat.number += _number;
        }

        public void OffBuff()
        {
            _gameStat.percent -= _percent;
            _gameStat.number -= _number;
        }
    }
}