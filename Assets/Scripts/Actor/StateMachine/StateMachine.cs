using System.Collections;
using System.Collections.Generic;
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
        OnHitted,
        NoControl,
    }

    public class StateMachine
    {
        private Dictionary<States, BaseState> _states = new Dictionary<States, BaseState>();
        public States CurrentState { get; private set; }
        
        private WrapBody _body;

        private Vector2 _directionX;

        public StateMachine(WrapBody body, Animator animator, ActorAnimController animController)
        {
            _body = body;
            InitStates(animator, animController);
        }

        private void InitStates(Animator animator, ActorAnimController animController)
        {
            _states.Add(States.OnGround, new OnGroundState(_body, animator, animController, this));
            _states.Add(States.OnAir, new OnAirState(_body, animator, animController, this));
            _states.Add(States.NoControl, new NoControlState(_body, animator, animController, this));
            _states.Add(States.OnDash, new OnDashState(_body, animator, animController, this));
            _states.Add(States.OnHitted, new OnHittedState(_body, animator, animController, this));

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
            if (_directionX.x != 0)
                _body.isPressing = true;
            else _body.isPressing = false;
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
