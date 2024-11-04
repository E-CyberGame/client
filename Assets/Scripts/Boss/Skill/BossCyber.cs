using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Boss.Skill
{
    public class BossCyber : NetworkBehaviour, ISpawned, IDespawned
    {
        // 임시 시리얼라이즈 필드
        LaySource vertical;
        LaySource horizontal;
        ExplosionSkill explosion;
        CloudSource cloud;


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
        private int skill_num = 3;
        private int vlaynum = 2;
        private int hlaynum = 2;
        [Networked] private bool is_Cloud {get; set;}

        public override void Spawned()
        {
            Init();
        }

        private void Init()
        {
            explosion = GetComponent<ExplosionSkill>();
            cloud = FindObjectOfType<CloudSource>();
            LaySource[] lays = FindObjectsOfType<LaySource>();
            horizontal = lays[0];
            vertical = lays[1];
            is_Cloud = false;

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
            Rpc_ActivateExplosion();
            yield return new WaitForSeconds(3.0f);
            CyberSkill();
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

        public void CloudReady()
        {
            is_Cloud = false;
        }
    }
}

