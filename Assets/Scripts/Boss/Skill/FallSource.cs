using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss.Skill
{
    public class FallSource : MonoBehaviour
    {
        FallSkill[] _fall;

        private void Start()
        {
            _fall = this.GetComponentsInChildren<FallSkill>();
        }

        public void Fall(int[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                _fall[source[i]].Activate();
            }
        }
    }
}

