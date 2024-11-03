using Fusion;
using UnityEngine;

namespace Actor.Skill
{
    public abstract class Projectile : NetworkBehaviour
    {
        protected NetworkMecanimAnimator _animator;
        //발사한 플레이어의 LayerMask
        protected LayerMask _playerLayer;
        //protected WrapBody _body;
        protected ActorStat _stat;
        //발사 거리
        protected Vector3 _distance;
        //소멸 딜레이
        protected float _destroyDelay;
        //스킬 시전 시 플레이어 위치
        protected Vector3 _startPlayerPosition;
        //스킬 시전 시 플레이어 방향
        protected Vector2 _startDirection;
        //생성 시작 포인트
        protected Vector3 _startPoint;

        public void Init(ActorStat stat, Vector3 startPlayerPosition, Vector3 startPoint)
        {
            _stat = stat;
            _startPlayerPosition = startPlayerPosition;
            _startPoint = startPoint;
            _animator = GetComponent<NetworkMecanimAnimator>();
            _playerLayer = _stat.gameObject.layer;
            MoveStartPoint();
        }

        public void Init(ActorStat stat, Vector2 startDirection, Vector3 startPlayerPosition, Vector3 startPoint, float destroyDelay)
        {
            Init(stat, startPlayerPosition, startPoint);
            _startDirection = startDirection;
            _destroyDelay = destroyDelay;
            MoveStartPoint();
        }
        
        public void Init(ActorStat stat, Vector2 startDirection, Vector3 startPlayerPosition, Vector3 startPoint, float destroyDelay, Vector3 distance)
        {
            Init(stat, startDirection, startPlayerPosition, startPoint, destroyDelay);
            _distance = distance;
        }
        

        public abstract void Fire();

        public abstract void Hit(IHitted target);
        
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            //추후 때려야 할 애들 레이어로...
            if (other.gameObject.layer != _playerLayer)
            {
                Hit(other.GetComponent<IHitted>());
            }
        }

        //로컬(Player 좌표 기준으로 이동)
        //월드 좌표는 쓰일 일 없을 것 같아서 안 만들어둠. 필요 시 생성.
        private void MoveStartPoint()
        {
            transform.position = _startPlayerPosition + _startPoint;
        }
        
        public void DestroyObject()
        {
            Runner.Despawn(gameObject.GetComponent<NetworkObject>());
        }
    }
}