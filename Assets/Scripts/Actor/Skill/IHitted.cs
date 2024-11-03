using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor.Skill
{
    public interface IHitted
    {
        public void Hitted(float damage);
        public void Hitted(IBuff buff, float time);
    }
}