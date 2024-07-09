using UnityEngine;

namespace Actor.Skill
{
    public class ActorHitted : MonoBehaviour, IHitted
    {
        public void Hitted()
        {
            Debug.Log("맞아버렷다");
        }
    }
}