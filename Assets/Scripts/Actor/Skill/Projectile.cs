using Fusion;
using UnityEngine;

namespace Actor.Skill
{
    using DG.Tweening;
    //발사체에 붙는 컴포넌트
    //현재 문제 : objectPath를 발사체 자체가 갖고 있음 안됨...
    public abstract class Projectile : NetworkBehaviour
    {
        //발사한 플레이어의 LayerMask
        protected LayerMask _playerLayer;
        //protected WrapBody _body;
        protected ActorStat _stat;
        //관통 횟수
        protected int _piercingCount = 0;
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

        public void Init(ActorStat stat, Vector2 startDirection, Vector3 startPlayerPosition, Vector3 startPoint, float destroyDelay)
        {
            _stat = stat;
            Debug.Log("초기화... 되었나요?;;");
            _startDirection = startDirection;
            _startPlayerPosition = startPlayerPosition;
            _startPoint = startPoint;
            _destroyDelay = destroyDelay;
            _playerLayer = _stat.gameObject.layer;
            MoveStartPoint();
        }
        
        public void Init(ActorStat stat, Vector2 startDirection, Vector3 startPlayerPosition, Vector3 startPoint, float destroyDelay, Vector3 distance)
        {
            Init(stat, startDirection, startPlayerPosition, startPoint, destroyDelay);
            _distance = distance;
        }
        

        public abstract void Fire();

        //로컬(Player 좌표 기준으로 이동)
        //월드 좌표는 쓰일 일 없을 것 같아서 안 만들어둠. 필요 시 생성.
        protected void MoveStartPoint()
        {
            transform.position = _startPlayerPosition + _startPoint;
        }
        
        //관통처리
        protected void Pierce()
        {
            if (_piercingCount > 0)
            {
                //관통은 int 횟수로 해야겠다 ㅋㅋ
                _piercingCount--;
            }
            else
            {
                Managers.Resources.Destroy(gameObject, 1f);
            }
        }
    }
}