using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

namespace Actor
{
    public enum States{
        OnGround,
        OnAir,
        NoControl,
    }

    public class StateMachine
    {
        private Dictionary<States, BaseState> _states = new Dictionary<States, BaseState>();
        public States CurrentState { get; private set; }
        
        private WrapBody _body;

        public StateMachine(ActorField _field, WrapBody body)
        {
            _body = body;
            InitStates(_field);
        }

        private void InitStates(ActorField _field)
        {
            BaseState.InitState(_field, _body);
            _states.Add(States.OnGround, new OnGroundState());
            _states.Add(States.OnAir, new OnAirState());

            CurrentState = States.OnGround;
        }
        
        private void ChangeState(States state)
        {
            ExitState();
            CurrentState = state;
            _states[CurrentState].EnterState();
            Debug.Log("CurrentState:" + state);
        }

        private void CheckChangeState()
        {
            if (_body.OnGround())
            {
                if(CurrentState != States.OnGround) ChangeState(States.OnGround);
            }
            else
            {
                if(CurrentState != States.OnAir) ChangeState(States.OnAir);
            }
        }

        public void UpdateState()
        {
            _states[CurrentState].UpdateState();
            CheckChangeState();
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
            _states[CurrentState].Move(input);
        }

        public void Jump()
        {
            _states[CurrentState].Jump();
        }

        public void Down()
        {
            _states[CurrentState].Down();
        }
    }
}
