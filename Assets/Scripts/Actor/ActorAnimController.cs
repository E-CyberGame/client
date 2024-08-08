using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public enum ActorAnim
    {
        Idle = 0,
        Running = 1,
        Jumping = 2,
        Dash = 3,
        Down = 4,
        Hit = 5,
        Hitted = 6,
    }
    public class ActorAnimController
    {
        private Animator _animator;
        public ActorAnim CurrentAnim { get; private set; } = ActorAnim.Idle;
        
        public ActorAnimController(Animator animator)
        {
            _animator = animator;
        }

        public void ChangeAnimation(ActorAnim animation)
        {
            Debug.Log(animation);
            CurrentAnim = animation;
            //_animator.Play(animation.ToString());
            _animator.SetInteger("currentAnimation", (int)animation);
        }
    }
}