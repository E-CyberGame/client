using Actor.Skill;
using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    // 광선형 스킬들의 기본형

    public class LaySkill : NetworkBehaviour, BSkill, BHit
    {
        [Networked][SerializeField] float _distanceX { get; set; }
        [Networked][SerializeField] float _distanceY { get; set; }
        [Networked][SerializeField] float _distanceZ { get; set; }

        [SerializeField] float _pre_width = 0.1f;
        [SerializeField] float _width = 1.0f;
        [SerializeField] Color _pre_color = new Color(1, 0, 0, 0.5f);
        [SerializeField] Color _color = new Color(0, 1, 0, 1.0f);
        LineRenderer _lineRenderer;
        private bool attacking = false;
        [SerializeField] int _lay_damage = 10;
        [SerializeField] int _lay_min = 0;
        [SerializeField] int _lay_max = 10;


        public void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void Activate()
        {
            Rpc_StartRay();
        }

        [Rpc(RpcSources.StateAuthority, RpcTargets.All)]
        private void Rpc_StartRay()
        {
            StartCoroutine(ShootingLay(_lineRenderer));
        }

        IEnumerator ShootingLay(LineRenderer lr)
        {
            //전조 레이저 빔
            PreLay(lr);
            yield return new WaitForSeconds(2.2f);
            DeactiveLay(lr);

            //실제 레이저 빔
            AttackLay(lr);
            yield return new WaitForSeconds(0.8f);
            DeactiveLay(lr);
        }

        void PreLay(LineRenderer lr)
        {
            lr.positionCount = 2;
            lr.startColor = _pre_color;
            lr.endColor = _pre_color;
            lr.startWidth = _pre_width;
            lr.endWidth = _pre_width;

            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, new Vector3(this.transform.position.x + _distanceX, this.transform.position.y + _distanceY, this.transform.position.z + _distanceZ));
        }

        void AttackLay(LineRenderer lr)
        {
            lr.positionCount = 2;
            lr.startColor = _color;
            lr.endColor = _color;
            lr.startWidth = _width;
            lr.endWidth = _width;

            lr.SetPosition(0, this.transform.position);
            lr.SetPosition(1, new Vector3(this.transform.position.x + _distanceX, this.transform.position.y + _distanceY, this.transform.position.z + _distanceZ));

            attacking = true;
        }

        public void SetRandomX()
        {
            _distanceX = Random.Range(_lay_min, _lay_max);
        }
        public void SetRandomY()
        {
            _distanceY = Random.Range(_lay_min, _lay_max);
        }

        void DeactiveLay(LineRenderer lr)
        {
            for(int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, Vector3.zero);
            }
            lr.positionCount = 0;
            attacking = false;
        }

        public void Hit(BHitted target)
        {

        }
    }
}
