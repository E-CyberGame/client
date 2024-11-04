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
        [SerializeField] int _lay_damage = 10;
        [SerializeField] int _lay_min = 0;
        [SerializeField] int _lay_max = 10;
        PolygonCollider2D line_collider;


        public void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.useWorldSpace = false;
            line_collider = gameObject.GetComponent<PolygonCollider2D>();
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

            lr.SetPosition(0, new Vector3(0, 0, 0));
            lr.SetPosition(1, new Vector3(_distanceX, _distanceY, _distanceZ));
        }

        void AttackLay(LineRenderer lr)
        {
            lr.positionCount = 2;
            lr.startColor = _color;
            lr.endColor = _color;
            lr.startWidth = _width;
            lr.endWidth = _width;

            lr.SetPosition(0, new Vector3(0, 0, 0));
            lr.SetPosition(1, new Vector3(_distanceX, _distanceY, _distanceZ));
            
            line_collider.SetPath(0, CalculateColliderPoints(lr)); //.ConvertAll(p=> (Vector2)transform.InverseTransformPoint(p))
            for(int i = 0; i< CalculateColliderPoints(lr).Count; i++)
            {
                Debug.Log(CalculateColliderPoints(lr)[i]);
            }
            line_collider.enabled = true;
        }  

        private List<Vector2> CalculateColliderPoints(LineRenderer lr)
        {
            Vector3[] positions = new Vector3[lr.positionCount];
            lr.GetPositions(positions);
            float dx = positions[1].x - positions[0].x;
            float dy = positions[1].y - positions[0].y;
            if (dx == 0) dx = 1;
            if (dy == 0) dy = 1;
            float m = dy / dx;
            float deltaX = (_width / 2f) * (m / Mathf.Pow(m * m + 1, 0.5f));
            float deltaY = (_width / 2f) * (1 / Mathf.Pow(m * m + 1, 0.5f));

            Vector3[] offsets = new Vector3[2];
            offsets[0] = new Vector3(-deltaX, deltaY);
            offsets[1] = new Vector3(deltaX, -deltaY);

            List<Vector2> colliderPositions = new List<Vector2>
            {
                positions[0] + offsets[0],
                positions[1] + offsets[0],
                positions[1] + offsets[1],
                positions[0] + offsets[1]
            };

            return colliderPositions;
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
            line_collider.enabled = false;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("TriggerEnter");
            //추후 때려야 할 애들 레이어로...
            if (!other.gameObject.layer.Equals("Enemy"))
            {
                Hit(other.GetComponent<IHitted>());
            }
        }

        public void Hit(IHitted target)
        {
            Debug.Log("Hit");
            if (!HasStateAuthority) return;
            if (target == null) return;
            target.Hitted(_lay_damage);
        }
    }
}
