using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Boss.Skill
{
    public class BossSubway : NetworkBehaviour, ISpawned
    {
        // 임시 시리얼라이즈 필드
        LaySource vertical;
        LaySource horizontal;
        FallSource fall;
        ExplosionSkill explosion;


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


        public override void Spawned()
        {
            Init();
        }

        private void Init()
        {
            explosion = GetComponent<ExplosionSkill>();
            fall = FindObjectOfType<FallSource>();
            LaySource[] lays = FindObjectsOfType<LaySource>();
            horizontal = lays[0];
            vertical = lays[1];

            Singleton = this;
            if (HasStateAuthority)
            {
                SkillStart();
            }
        }

        public override void Despawned(NetworkRunner runner, bool hasState)
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
            Debug.Log("세로 빔");
            vertical.Lay(vlaynum);
            yield return new WaitForSeconds(8.0f);
            SubwaySkill();
        }
        IEnumerator VLaySkill()
        {
            Debug.Log("가로 빔");
            horizontal.Lay(hlaynum);
            yield return new WaitForSeconds(8.0f);
            SubwaySkill();
        }

        IEnumerator FallSkill()
        {
            Debug.Log("운석");
            fall.Fall(fallnum);
            yield return new WaitForSeconds(10.0f);
            SubwaySkill();
        }
        IEnumerator LateFallSkill()
        {
            Debug.Log("지연술+ 운석");
            fall.LateFall(fallnum);
            yield return new WaitForSeconds(15.0f);
            SubwaySkill();
        }

        IEnumerator ExplosionSkill()
        {
            Debug.Log("폭발");
            Rpc_ActivateExplosion();
            yield return new WaitForSeconds(6.0f);
            SubwaySkill();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_ActivateExplosion()
        {
            explosion.Activate();
        }
        public Vector3 GetTransform()
        {
            return transform.position;
        }
    }
}

