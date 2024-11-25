using UnityEngine;
using Web.DTO;

namespace Data
{
    public class PlayerInfo : MonoSingleton<PlayerInfo>
    {
        public CharacterInfoDTO info { get; set; } = new CharacterInfoDTO(
            "SYEON.K", CharacterType.Youtuber, 100, 10, 30);
        public CharacterStatDTO stat { get; set; } = new CharacterStatDTO(
            300, 100, 20, 10, 0.3f, 0.5f, 2);
    }
}