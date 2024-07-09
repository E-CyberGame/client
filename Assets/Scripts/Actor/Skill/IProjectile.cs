using UnityEngine;

namespace Actor.Skill
{
    public abstract class IProjectile : MonoBehaviour
    {
        //실제로 구현될 발사체
        public GameObject go { get; protected set; }
        public abstract void Fire();
    }
}