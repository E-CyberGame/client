using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossController : MonoBehaviour
    {
        private BossStat _stat;
        private StateMachine _stateMachine;
        private BossSkillController _skill; // �������� ������ ��ų ��Ʈ�ѷ� �ٿ��ֱ�??

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


