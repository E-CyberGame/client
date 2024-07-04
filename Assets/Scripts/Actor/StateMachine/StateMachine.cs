using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

//응용
namespace Actor
{
    public enum States{
        OnGround,
        OnAir,
        OnDash,
        NoControl,
    }

    public class StateMachine
    {
        private Dictionary<States, BaseState> _states = new Dictionary<States, BaseState>();
        public States CurrentState { get; private set; }
        
        private WrapBody _body;

        private Vector2 _directionX;

        public StateMachine(WrapBody body, Animator animator)
        {
            _body = body;
            InitStates(animator);
        }

        private void InitStates(Animator animator)
        {
            BaseState.InitState(_body, animator, this);
            _states.Add(States.OnGround, new OnGroundState());
            _states.Add(States.OnAir, new OnAirState());
            _states.Add(States.NoControl, new NoControlState());
            _states.Add(States.OnDash, new OnDashState());

            CurrentState = States.OnGround;
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

        public void Jump()
        {
            _states[CurrentState].Jump();
        }

        public void Down()
        {
            _states[CurrentState].Down();
        }

        public void Dash()
        {
            ChangeState(States.OnDash);
        }
    }
}
