using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Web.DTO;

namespace Web.DTO
{
    public class CharacterStatDTO : DTO
    {
        public float max_hp { get; set; }
        public float max_mp { get; set; }
        public float atk { get; set; }
        public float def { get; set; }
        public float cri_percent { get; set; }
        public float cri_damage { get; set; }
        public float speed { get; set; }

        public CharacterStatDTO(float max_hp, float max_mp, float atk, float def, float cri_percent, float cri_damage, float speed)
        {
            this.max_hp = max_hp;
            this.max_mp = max_mp;
            this.atk = atk;
            this.def = def;
            this.cri_percent = cri_percent;
            this.cri_damage = cri_damage;
            this.speed = speed;
        }
    }
}