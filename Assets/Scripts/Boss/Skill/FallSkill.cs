using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class FallSkill : MonoBehaviour, BSkill
    {
        // 바닥에 닿으면 부서지는 것으로 교체 예정
        [SerializeField] float fall_time = 1.5f;
        public GameObject _rock;


        public void Activate()
        {
            _rock = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Rock"), new Vector3(0, 8, 0));
            StartCoroutine(Explosion());
        }

        IEnumerator Explosion()
        {
            yield return new WaitForSeconds(fall_time);
            GameObject.Destroy(_rock);
            Debug.Log("떨어졌습니다.");
        }
    }

}

