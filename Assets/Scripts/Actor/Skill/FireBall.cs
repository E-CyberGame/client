using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Actor.Skill
{
    public class FireBall : Projectile, IHit
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
            Pierce(generated_go);
        }

        //Generate랑 Fire이 Projectile Skill로 이동해야 하는 거 아님...?
        public override void Generate()
        {
            generated_go = Managers.Resources.Instantiate(go);
            Managers.Resources.Destroy(generated_go, 1f);
        }

        public override void Fire()
        {
            generated_go.transform.DOLocalMove(new Vector3(10f, 0f, 0f), 1f);
        }
    }
}