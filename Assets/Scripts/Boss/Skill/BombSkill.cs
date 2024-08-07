using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class BombSkill : MonoBehaviour, BSkill
    {
        [SerializeField] float explosion_time = 2.0f;
        public GameObject _bomb;


        public void Activate()
        {
            _bomb = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Bomb"), transform.position);
            StartCoroutine(Explosion());
        }

        IEnumerator Explosion()
        {
            yield return new WaitForSeconds(explosion_time);
            GameObject.Destroy(_bomb);
            Debug.Log("폭발했습니다.");
        }

    }
}
