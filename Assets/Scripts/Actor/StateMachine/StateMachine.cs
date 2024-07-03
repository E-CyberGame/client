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

        public StateMachine(ActorField _field, WrapBody body, Animator animator)
        {
            _body = body;
            InitStates(_field, animator);
        }

        private void InitStates(ActorField _field, Animator animator)
        {
            BaseState.InitState(_field, _body, animator);
            _states.Add(States.OnGround, new OnGroundState());
            _states.Add(States.OnAir, new OnAirState());
            _states.Add(States.NoControl, new NoControlState());
            _states.Add(States.OnDash, new OnDashState());

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
            if (CurrentState == States.OnDash)
                return;
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
            CoroutineHelper.Instance.StartCoroutineHelper(EscapeDash());
        }

        IEnumerator EscapeDash()
        {
            yield return new WaitForSeconds(0.2f);
            if (_body.OnGround())
            {
                ChangeState(States.OnGround);
            }
            else
            {
                ChangeState(States.OnAir);
            }
        }
    }
}
