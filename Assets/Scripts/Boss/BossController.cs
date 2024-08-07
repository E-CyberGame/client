using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossController : MonoBehaviour
    {
        private BossStat _stat;
        private StateMachine _stateMachine;
        private BossSkillController _skill; // 보스마다 고유한 스킬 컨트롤러 붙여주기??

        void Awake()
        {
            _stat = GetComponent<BossStat>();
            _skill = GetComponent<BossSkillController>();
            _stateMachine = new StateMachine(GetComponent<WrapBody>(), GetComponent<Animator>());
        }

        void Update()
        {
            _stateMachine.UpdateState();
        }
        void FixedUpdate()
        {
            _stateMachine.FixedUpdateState();
        }

    }
}


