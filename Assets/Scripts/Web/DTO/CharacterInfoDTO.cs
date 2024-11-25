using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Web.DTO;

public class CharacterInfoDTO : DTO
{
    public string name { get; set; }
    public CharacterType character { get; set; }
    public int exp { get; set; }
    public int level { get; set; }
    public int gold { get; set; }
    public int crystal { get; set; }
    public int decay { get; set; }

    public CharacterInfoDTO(string name, CharacterType character, int exp, int level, int gold, int crystal, int decay)
    {
        this.name = name;
        this.character = character;
        this.exp = exp;
        this.level = level;
        this.gold = gold;
        this.crystal = crystal;
        this.decay = decay;
    }
}
