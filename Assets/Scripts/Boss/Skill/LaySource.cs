using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Boss.Skill {

    public class LaySource : MonoBehaviour
    {
        LaySkill[] _lay;
        private int _layLen;

        private void Start()
        {
            _lay = this.GetComponentsInChildren<LaySkill>();
            _layLen = _lay.Length;
        }

        public void Lay(int count)
        {
            List<int> list = new List<int>();
            for(int i = 0; i < _layLen; i++)
            {
                list.Add(i);
            }
            for(int i =  0; i < _layLen - count; i++)
            {
                int r = Random.Range(0, list.Count);
                list.Remove(list[r]);
            }
            for(int i = 0; i < list.Count; i++)
            {
                _lay[list[i]].Activate();
            }
        }

        public void SetRandomX()
        {
            for (int i = 0; i < _layLen; i++)
            {
                _lay[i].SetRandomX();
            }
        }
        public void SetRandomY()
        {
            for (int i = 0; i < _layLen; i++)
            {
                _lay[i].SetRandomY();
            }
        }
    }


}
