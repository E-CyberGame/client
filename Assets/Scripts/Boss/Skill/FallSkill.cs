using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill
{
    public class FallSkill : MonoBehaviour, BSkill
    {
        public GameObject _rock;
        public void Activate()
        {
            _rock = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Rock"), transform.position);
            Falling falling = _rock.GetComponent<Falling>();
            falling.Init(_rock);
        }

    }

}

