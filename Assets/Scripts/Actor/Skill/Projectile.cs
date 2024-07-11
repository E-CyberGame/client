using UnityEngine;

namespace Actor.Skill
{
    using DG.Tweening;
    //발사체에 붙는 컴포넌트
    public abstract class Projectile : MonoBehaviour
    {
        //발사체
        public GameObject go { get; protected set; }
        protected GameObject generated_go;
        
        //관통 횟수
        protected int piercingCount;
        //발사 거리
        protected int distance;
        //소멸 딜레이
        protected float destroyDelay;

        //발사체 구현
        public abstract void Generate();
        
        //발사체 발사
        public abstract void Fire();

        protected void Pierce(GameObject projectile)
        {
            if (piercingCount > 0)
            {
                //관통은 int 횟수로 해야겠다 ㅋㅋ
            }
            else
            {
                Managers.Resources.Destroy(generated_go, 1f);
            }
        }
    }
}