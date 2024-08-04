using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class FallSkill : MonoBehaviour, BSkill
    {
        // �ٴڿ� ������ �μ����� ������ ��ü ����
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
            Debug.Log("���������ϴ�.");
        }
    }

}

