using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class FireBall : IProjectile, IHit
    {
        public FireBall()
        {
            go = Resources.Load<GameObject>("TestPrefabs/testBall");
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            Hit(other.GetComponent<IHitted>());
        }

        public void Hit(IHitted target)
        {
            Debug.Log("때려버렷다");
            target.Hitted();
        }

        public override void Fire()
        {
            
        }
    }
}