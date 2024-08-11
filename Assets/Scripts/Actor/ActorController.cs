using System.Numerics;
using Actor.Skill;
using UnityEngine;
using UnityEngine.InputSystem;
using Fusion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Actor
{
    public class ActorController : NetworkBehaviour, IHitted
    {
        private NetworkTransform _transform;
        private ActorStat _stat;
        public StateMachine _stateMachine { get; private set; }
        private SkillController _skill;

        void Awake()
        {
            _transform = GetComponent<NetworkTransform>();
            _stat = GetComponent<ActorStat>();
            _skill = GetComponent<SkillController>();
            _stateMachine = new StateMachine(GetComponent<WrapBody>(), GetComponent<Animator>(), GetComponent<ActorAnimController>());
        }
        void Start()
        {
            /*if(CompareTag("Player"))
                _stat.HP.SetStat(50f);*/
        }

        void Update()
        {
            _stateMachine.UpdateState();
        }

        public override void FixedUpdateNetwork()
        {
            if (HasStateAuthority == false)
            {
                return;
            }
            _stateMachine.FixedUpdateState();
            _transform.transform.position = transform.position;

        }

        #region Additional Input

        public void OnMove(InputValue input)
        {
            Vector2 direction = input.Get<Vector2>();

            if (HasStateAuthority)
            {
                if (direction.x == 1.0f)
                    transform.eulerAngles = Vector3.down * -180f;
                else if (direction.x == -1.0f) transform.eulerAngles = Vector3.zero;
            }
            
            _stateMachine.Move(direction);
        }

        public void OnJump()
        {
            _stateMachine.Jump();
        }

        public void OnDown()
        {
            _stateMachine.Down();
        }

        public void OnDash()
        {
            _stateMachine.Dash();
        }

        #endregion

        public void Hitted(float damage, IBuff buff = null)
        {
            Debug.Log($"{damage} 맞아부럿성...");
            _stat.HP.AddStat(-damage);
            _stateMachine.ChangeState(States.OnHitted);
        }
    }

}
