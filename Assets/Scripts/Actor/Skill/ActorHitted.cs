using UnityEngine;

namespace Actor.Skill
{
    public class ActorHitted : MonoBehaviour, IHitted
    {
        public void Hitted(float damage, IBuff buff = null)
        {
            Debug.Log($"{damage} 맞아버렷다");
        }
    }
}