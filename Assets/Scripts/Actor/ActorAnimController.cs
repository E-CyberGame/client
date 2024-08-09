using System.Collections.Generic;
using Fusion;
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
    public class ActorAnimController : NetworkBehaviour
    {
        private Animator _animator;
        public ActorAnim CurrentAnim { get; private set; } = ActorAnim.Idle;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public ActorAnimController(Animator animator)
        {
            _animator = animator;
        }

        //[Rpc]
        public void ChangeAnimation(ActorAnim animation)
        {
            CurrentAnim = animation;
            _animator.SetInteger("currentAnimation", (int)animation);
        }
    }
}