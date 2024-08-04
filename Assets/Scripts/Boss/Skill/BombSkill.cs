using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class BombSkill : MonoBehaviour, BSkill
    {
        [SerializeField] float explosion_time = 2.0f;
        public GameObject Bomb;


        public void Activate()
        {
            Bomb = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Bomb"), new Vector3(0, 0, 0));
            StartCoroutine(Explosion());
        }

        IEnumerator Explosion()
        {
            yield return new WaitForSeconds(explosion_time);
            GameObject.Destroy(Bomb);
            Debug.Log("폭발했습니다.");
        }

    }
}
