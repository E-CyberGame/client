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
        private ActorStat _stat;
        public StateMachine _stateMachine { get; private set; }
        private SkillController _skill;

        [Networked] private NetworkButtons PreviousMoveButtons { get; set; }
        [Networked] private NetworkButtons PreviousSkillButtons { get; set; }


        [Networked]
        public TickTimer PlayerTimer { get; set; }

        private bool _startTimer = false;

        void Awake()
        {
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
            if (GetInput(out PlayerNetworkInput input))
            {
                if (input.MoveButtons.WasPressed(PreviousMoveButtons, InputButton.Jump))
                    _stateMachine.Jump();
                if (input.MoveButtons.WasPressed(PreviousMoveButtons, InputButton.Dash))
                    _stateMachine.Dash();
                if (input.MoveButtons.WasPressed(PreviousMoveButtons, InputButton.Down))
                    _stateMachine.Down();
                
                if (input.SkillButtons.WasPressed(PreviousSkillButtons, SkillButton.A))
                    _skill.UseSkill(SkillSlot.slot1);
                if (input.SkillButtons.WasPressed(PreviousSkillButtons, SkillButton.S))
                    _skill.UseSkill(SkillSlot.slot2);
                
                if (input.Direction.x == 1.0f)
                    transform.eulerAngles = Vector3.down * -180f;
                else if (input.Direction.x == -1.0f) transform.eulerAngles = Vector3.zero;

                _stateMachine.Move(input.Direction);
            }
            
            PreviousMoveButtons = input.MoveButtons;
            
            _stateMachine.FixedUpdateState();

            if (_startTimer && PlayerTimer.Expired(Runner))
            {
                _startTimer = false;
                _stateMachine.ChangeState(States.OnGround);
            }
        }

        public void SetPlayerLocation(Vector3 location)
        {
            transform.position = location;
        }

        public void SetTimer(TickTimer timer)
        {
            _startTimer = true;
            PlayerTimer = timer;
            _stateMachine.ChangeState(States.NoControl);
        }

        public void Hitted(float damage, IBuff buff = null)
        {
            Debug.Log($"{damage} 맞아부럿성...");
            _stat.hp -= damage;
            Debug.Log("값이우찌되오" + _stat.hp);
            _stateMachine.ChangeState(States.OnHitted);
        }
    }

}
