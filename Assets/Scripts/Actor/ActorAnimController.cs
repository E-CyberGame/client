using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public enum ActorAnim
    {
        Idle = 0,
        Running = 1,
        Jumping = 2,
        Dashing = 3,
        Falling = 4,
    }
    public class ActorAnimController
    {
        private Animator _animator;
        public ActorAnim CurrentAnim { get; private set; } = ActorAnim.Idle;
        
        public ActorAnimController(Animator animator)
        {
            _animator = animator;
        }

        public void changeAnimation(ActorAnim animation)
        {
            Debug.Log(animation);
            CurrentAnim = animation;
            _animator.SetInteger("currentAnimation", (int)animation);
        }
    }
}