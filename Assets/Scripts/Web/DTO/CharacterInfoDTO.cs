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
    public int crystal { get; set; }
    public int decay { get; set; }

    public CharacterInfoDTO(string name, CharacterType character, int exp, int crystal, int decay)
    {
        this.name = name;
        this.character = character;
        this.exp = exp;
        this.crystal = crystal;
        this.decay = decay;
    }
}
