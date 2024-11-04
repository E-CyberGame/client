using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Web.DTO;

public class CharacterInfoDTO : DTO
{
    public string name { get; set; }
    public int character { get; set; }
    public int level { get; set; }
    public int crystal { get; set; }
    public int gold { get; set; }

    public CharacterInfoDTO(string name, CharacterType type, int level, int crystal, int gold)
    {
        this.name = name;
        this.character = (int)type;
        this.level = level;
        this.crystal = crystal;
        this.gold = gold;
    }
}
