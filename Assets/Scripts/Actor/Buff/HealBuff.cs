using System.Collections;
using UnityEngine;

namespace Actor.Buff
{
    public class HealBuff : IBuff
    {
        private ActorStat _stat;
        private float _repeatTime;
        private int _healAmount;

        public HealBuff(ActorStat stat, float repeatTime, int healAmount)
        {
            _stat = stat;
            _repeatTime = repeatTime;
            _healAmount = healAmount;
        }
        
        private Coroutine _coroutine;
        public void OnBuff()
        {
            _coroutine = CoroutineHelper.Instance.StartCoroutineHelper(Heal());
        }

        public void OffBuff()
        {
            CoroutineHelper.Instance.StopCoroutineHelper(_coroutine);
        }

        IEnumerator Heal()
        {
            _stat.Heal(_healAmount);
            yield return new WaitForSeconds(_repeatTime);
        }
    }
}