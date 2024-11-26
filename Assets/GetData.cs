using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;
using Web;
using Web.DTO;

public class GetData : MonoBehaviour
{
    [SerializeField] private WebConnection _webConnection;

    void Awake()
    {
        _webConnection.SendGet<ResponseDto>("user-info/" + PlayerInfo.Instance.userID,
            response =>
            {
                PlayerInfo.Instance.info = new CharacterInfoDTO(
                    response.data.user.userNickname, response.data.characterInfo.charType,
                    response.data.userCharacter.ownExp, response.data.userCharacter.ownLevel,
                    response.data.user.gold, response.data.user.crystal, 0);
            });
    }

}
