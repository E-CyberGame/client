using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Boss.Skill
{
    public class BossCyber : MonoBehaviour
    {
        // 임시 시리얼라이즈 필드
        [SerializeField] LaySource vertical;
        [SerializeField] LaySource horizontal;
        [SerializeField] MirrorSkill mirror;
        [SerializeField] ExplosionSkill explosion;
        [SerializeField] CloudSource cloud;


        public static BossCyber Singleton
        {
            get => _cybersingleton;
            set
            {
                if (value == null)
                    _cybersingleton = null;
                else if (_cybersingleton == null)
                    _cybersingleton = value;
                else if (_cybersingleton != value)
                {
                    Destroy(value);
                    //Debug.LogError($"There should only ever be one instance of {nameof(NetUIMananger)}!");
                }
            }
        }
        private static BossCyber _cybersingleton;
        private int skill_num = 4;
        private int vlaynum = 2;
        private int hlaynum = 2;
        private bool is_Cloud = false;


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
            CyberSkill();
        }

        public void CyberSkill()
        {
            int r = Random.Range(0, skill_num);
            Debug.Log(r);
            switch (r) { 
                case 0: StartCoroutine(LaySkill()); break;
                case 1: StartCoroutine(ExplosionSkill()); break;
                case 2: StartCoroutine(CloudSkill()); break;
                default: CyberSkill(); break; 
            }

        }

        IEnumerator LaySkill()
        {
            Debug.Log("교차 빔");
            vertical.SetRandomX();
            horizontal.SetRandomY();
            vertical.Lay(vlaynum);
            horizontal.Lay(hlaynum);
            yield return new WaitForSeconds(4.0f);
            CyberSkill();
        }

        IEnumerator CloudSkill()
        {
            if (is_Cloud)
            {
                CyberSkill();
                yield break;
            }

            Debug.Log("구름 소환");
            cloud.CloudSpawn();
            is_Cloud = true;
            yield return new WaitForSeconds(3.0f);
            CyberSkill();
        }

        IEnumerator ExplosionSkill()
        {
            Debug.Log("폭발");
            explosion.Activate();
            yield return new WaitForSeconds(3.0f);
            CyberSkill();
        }

        public Vector3 GetTransform()
        {
            return transform.position;
        }

        public void CloudReady()
        {
            is_Cloud = false;
        }
    }
}

