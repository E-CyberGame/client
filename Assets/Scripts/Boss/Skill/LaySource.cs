using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill {

    public class LaySource : MonoBehaviour
    {
        LaySkill[] _lay;

        private void Start()
        {
            _lay = this.GetComponentsInChildren<LaySkill>();
        }

        public void Lay(int[] source)
        {
            for(int i =  0; i < source.Length; i++)
            {
                _lay[source[i]].Activate();
            }
        }
    }


}
