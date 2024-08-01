using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss.Skill
{
    public interface IHit
    {
        public void Hit(IHitted target);
    }
}
