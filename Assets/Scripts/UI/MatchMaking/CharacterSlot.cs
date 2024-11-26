using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class CharacterSlot : NetworkBehaviour
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI nickName;
    [SerializeField] private GameObject ready;

    PlayerObject _player = null;
    PlayerObject Player
    {
        get
        {
            if (_player == null) _player = PlayerRegistry.GetPlayer(Object.InputAuthority);
            return _player;
        }
    }

    public override void Spawned()
    {
        // characterImage.sprite = Database.CharacterData.GetData(Player.Character).CardImage;
        // nickName.name = Player.name;
    }

    public void SetData(CharacterType characterType, string nickname)
    {
        Debug.Log(Database.CharacterData.GetData(characterType).CardImage);
        Debug.Log(nickname);
        characterImage.sprite = Database.CharacterData.GetData(characterType).SlotImage;
        nickName.text = nickname;
    }

    public void SetReady(bool areReady)
    {
        ready.SetActive(areReady);
    }
}
