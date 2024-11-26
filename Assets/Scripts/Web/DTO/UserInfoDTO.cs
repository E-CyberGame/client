using Data;

namespace Web.DTO
{
    public class ResponseDto : DTO
    {
        public string message { get; set; }
        public DataDto data { get; set; }
    }

    public class DataDto
    {
        public UserDto user { get; set; }
        public CharacterInfoDto characterInfo { get; set; }
        public UserCharacterDto userCharacter { get; set; }
    }

    public class UserDto
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userNickname { get; set; }
        public int gold { get; set; }
        public int crystal { get; set; }
    }

    public class CharacterInfoDto
    {
        public int charId { get; set; }
        public string charName { get; set; }
        public CharacterType charType { get; set; }
    }

    public class UserCharacterDto
    {
        public int ownId { get; set; }
        public int ownExp { get; set; }
        public int ownLevel { get; set; }
        public CharacterInfoDto characterInfo { get; set; }
    }

}