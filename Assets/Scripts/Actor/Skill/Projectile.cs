using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

namespace Actor.Skill
{
    using DG.Tweening;
    //발사체에 붙는 컴포넌트
    //현재 문제 : objectPath를 발사체 자체가 갖고 있음 안됨...
    public abstract class Projectile : MonoBehaviour
    {
        protected WrapBody _body;
        protected ActorStat _stat;
        //관통 횟수
        protected int _piercingCount = 0;
        //발사 거리
        protected Vector3 _distance;
        //소멸 딜레이
        protected float _destroyDelay;
        //생성 시작 포인트
        protected Vector3 _startPoint;

        public void Init(WrapBody body, ActorStat stat, Vector3 startPoint, float destroyDelay, Vector3 distance, int piercingCount)
        {
            _body = body;
            _stat = stat;
            _startPoint = startPoint;
            _distance = distance;
            _destroyDelay = destroyDelay;
            _piercingCount = piercingCount;
            MoveStartPoint();
        }
        
        public void Init(WrapBody body, ActorStat stat, Vector3 startPoint, float destroyDelay, Vector3 distance)
        {
            _body = body;
            _stat = stat;
            _startPoint = startPoint;
            _distance = distance;
            _destroyDelay = destroyDelay;
            MoveStartPoint();
        }

        public abstract void Fire();

        //로컬(Player 좌표 기준으로 이동)
        //월드 좌표는 쓰일 일 없을 것 같아서 안 만들어둠. 필요 시 생성.
        protected void MoveStartPoint()
        {
            transform.position += _startPoint;
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