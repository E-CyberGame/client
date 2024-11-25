using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class FallSkill : NetworkBehaviour, BSkill
    {
        [SerializeField] GameObject clock;
        float _pre = 1.0f;
        float _late = 4.0f;

        public void Activate()
        {
            StartFall();
        }

        public void LateActivate()
        {
            Rpc_SetClock(true);
            StartCoroutine(LateStartFall());
        }

        void StartFall()
        {
            GameObject _rock = Resources.Load<GameObject>("Prefabs/Boss/Rock".ToString());
            Runner.Spawn(_rock, position: this.transform.position, onBeforeSpawned: ObjBeforeSpawn);
            Falling falling = _rock.GetComponent<Falling>();
        }

        IEnumerator LateStartFall()
        {
            GameObject _rock = Resources.Load<GameObject>("Prefabs/Boss/Rock".ToString());
            Runner.Spawn(_rock, position: this.transform.position, onBeforeSpawned: LateObjBeforeSpawn);
            yield return new WaitForSeconds(_late);
            Rpc_SetClock(false);
        }

        private void ObjBeforeSpawn(NetworkRunner runner, NetworkObject obj)
        {
            obj.GetComponent<Falling>().delay = _pre;
            obj.GetComponent<Falling>().speed += Random.Range(0, 500) * 0.0001f;
        }
        private void LateObjBeforeSpawn(NetworkRunner runner, NetworkObject obj)
        {
            obj.GetComponent<Falling>().delay = _pre + _late;
            obj.GetComponent<Falling>().speed += Random.Range(0, 500) * 0.0001f;
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_SetClock(bool clockset)
        {
            clock.SetActive(clockset);
        }
    }

}

