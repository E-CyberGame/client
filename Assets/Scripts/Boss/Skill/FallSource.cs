using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss.Skill
{
    public class FallSource : MonoBehaviour
    {
        FallSkill[] _fall;
        private int _fallLen;

        private void Start()
        {
            _fall = this.GetComponentsInChildren<FallSkill>();
            _fallLen = _fall.Length;
        }

        public void Fall(int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _fallLen; i++)
            {
                list.Add(i);
            }
            for (int i = 0; i < _fallLen - count; i++)
            {
                int r = Random.Range(0, list.Count);
                list.Remove(list[r]);
            }
            for (int i = 0; i < list.Count; i++)
            {
                _fall[list[i]].Activate();
            }
        }
        public void LateFall(int count)
        {
            List<int> fast = new List<int>();
            List<int> late = new List<int>();
            for (int i = 0; i < _fallLen; i++)
            {
                fast.Add(i);
            }
            for (int i = 0; i < _fallLen - count; i++)
            {
                int r = Random.Range(0, fast.Count);
                late.Add(fast[r]);
                fast.Remove(fast[r]);
            }
            for(int i=0; i < fast.Count; i++)
            {
                _fall[fast[i]].Activate();
            }
            for (int i = 0; i < late.Count; i++)
            {
                _fall[late[i]].LateActivate();
            }
        }
    }
}

