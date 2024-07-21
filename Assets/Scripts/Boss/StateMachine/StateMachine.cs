using Actor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public enum States {
        Idle, //대체어가 없다... 보스는 OnGround가 아닐 수도?
        Moving,
        CoolDown, // 작명 고민... 스킬 사용 쿨타임 중
        UsingSkill,
        Groggy,
        // 기타 상태...
    }

    public class StateMachine
    {
        private Dictionary<States, BaseState> _states = new Dictionary<States, BaseState>();
        public States CurrentState { get; private set; }

        private WrapBody _body; // 이거 어쩔지 고민해야함

        private Vector2 _directionX;

        public StateMachine(WrapBody body, Animator animator)
        {
            _body = body;
            InitStates(animator);
        }

        private void InitStates(Animator animator)
        {
            BaseState.InitState(_body, animator, this);
            _states.Add(States.Idle, new OnIdleState());
            _states.Add(States.Moving, new OnMovingState());
            _states.Add(States.CoolDown, new OnCoolDownState());
            _states.Add(States.UsingSkill, new OnUsingSkillState());
            _states.Add(States.Groggy, new OnGroggyState());

            CurrentState = States.Idle;
        }

        public void ChangeState(States state)
        {
            ExitState();
            CurrentState = state;
            _states[CurrentState].EnterState();
            Debug.Log("CurrentState:" + state);
        }

        public void UpdateState()
        {
            _states[CurrentState].UpdateState();
        }

        public void FixedUpdateState()
        {
            _states[CurrentState].FixedUpdateState();
        }

        private void ExitState()
        {
            _states[CurrentState].ExitState();
        }

        public void Move(Vector2 input)
        {
            _directionX = input;
            _states[CurrentState].Move(_directionX);
        }

    }
}

