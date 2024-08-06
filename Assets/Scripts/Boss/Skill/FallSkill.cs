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
            _rock = Managers.Resources.Instantiate(Managers.Resources.Load<GameObject>("Prefabs/Rock"), new Vector3(0, 8, 0));
            Falling falling = _rock.GetComponent<Falling>();
            falling.Init(_rock);
        }

    }

}

