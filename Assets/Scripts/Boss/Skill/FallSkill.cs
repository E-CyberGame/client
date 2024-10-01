using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class FallSkill : MonoBehaviour, BSkill
    {
        [SerializeField]
        GameObject clock;
        GameObject _rock;
        float _pre = 1.0f;
        float _late = 4.0f;

        public void Activate()
        {
            StartCoroutine(StartFall());
        }

        public void LateActivate()
        {
            clock.SetActive(true);
            StartCoroutine(LateStartFall());
        }

        IEnumerator StartFall()
        {
            _rock = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Rock"), transform.position);
            Falling falling = _rock.GetComponent<Falling>();
            falling.Init(_rock);
            yield return new WaitForSeconds(_pre);
            falling.Wake();
        }

        IEnumerator LateStartFall()
        {
            _rock = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Rock"), transform.position);
            Falling falling = _rock.GetComponent<Falling>();
            falling.Init(_rock);
            yield return new WaitForSeconds(_pre);
            yield return new WaitForSeconds(_late);
            falling.Wake();
            clock.SetActive(false);
        }
    }

}

