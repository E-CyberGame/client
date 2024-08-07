using Boss.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSource : MonoBehaviour
{
    BombSkill[] _bomb;

    private void Start()
    {
        _bomb = this.GetComponentsInChildren<BombSkill>();
    }

    public void Bomb(int[] source)
    {
        for (int i = 0; i < source.Length; i++)
        {
            _bomb[source[i]].Activate();
        }
    }
}
