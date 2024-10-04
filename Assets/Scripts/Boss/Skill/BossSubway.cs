using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Boss.Skill
{
    public class BossSubway : MonoBehaviour
    {
        // �ӽ� �ø�������� �ʵ�
        [SerializeField] LaySource vertical;
        [SerializeField] LaySource horizontal;
        [SerializeField] FallSource fall;
        [SerializeField] ExplosionSkill explosion;
        [SerializeField] BombSource bomb;


        public static BossSubway Singleton
        {
            get => _subwaysingleton;
            set
            {
                if (value == null)
                    _subwaysingleton = null;
                else if (_subwaysingleton == null)
                    _subwaysingleton = value;
                else if (_subwaysingleton != value)
                {
                    Destroy(value);
                    //Debug.LogError($"There should only ever be one instance of {nameof(NetUIMananger)}!");
                }
            }
        }
        private static BossSubway _subwaysingleton;
        private int skill_num = 5;
        private int vlaynum = 5;
        private int hlaynum = 3;
        private int fallnum = 10;


        public void Awake()
        {
            Singleton = this;
        }

        public void Start()
        {
            SkillStart();
        }

        private void OnDestroy()
        {
            if (Singleton == this)
                Singleton = null;
        }

        public void SkillStart()
        {
            SubwaySkill();
        }

        public void SubwaySkill()
        {
            int r = Random.Range(0, skill_num);
            Debug.Log(r);
            switch (r) { 
                case 0: StartCoroutine(HLaySkill()); break;
                case 1: StartCoroutine(ExplosionSkill()); break;
                case 2: StartCoroutine(FallSkill()); break;
                case 3: StartCoroutine(LateFallSkill()); break;
                case 4: StartCoroutine(VLaySkill()); break;
                default: break; 
            }

        }

        IEnumerator HLaySkill()
        {
            Debug.Log("���� ��");
            vertical.Lay(vlaynum);
            yield return new WaitForSeconds(4.0f);
            SubwaySkill();
        }
        IEnumerator VLaySkill()
        {
            Debug.Log("���� ��");
            horizontal.Lay(hlaynum);
            yield return new WaitForSeconds(4.0f);
            SubwaySkill();
        }

        IEnumerator FallSkill()
        {
            Debug.Log("�");
            fall.Fall(fallnum);
            yield return new WaitForSeconds(6.0f);
            SubwaySkill();
        }
        IEnumerator LateFallSkill()
        {
            Debug.Log("������+ �");
            fall.LateFall(fallnum);
            yield return new WaitForSeconds(10.0f);
            SubwaySkill();
        }

        IEnumerator ExplosionSkill()
        {
            Debug.Log("����");
            explosion.Activate();
            yield return new WaitForSeconds(3.0f);
            SubwaySkill();
        }
    }
}

