using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public StateMachine(ActorStat stat, Transform tr, Rigidbody2D rigid)
        {
            _body = new WrapBody(stat, tr, rigid);
            InitStates(stat);
        }

        private void InitStates(ActorStat stat)
        {
            _states.Add(States.OnGround, new OnGroundState(stat, _body));
            _states.Add(States.OnAir, new OnAirState(stat, _body));

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
        
        public void OnMove(Vector2 horizontal)
        {
            
        }

        public void OnJump()
        {
            
        }

        public void OnDown()
        {

        }
    }
}
