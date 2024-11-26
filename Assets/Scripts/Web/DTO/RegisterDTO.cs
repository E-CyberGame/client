using Data;

namespace Web.DTO
{
    public class RegisterDTO : DTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string user_nickname { get; set; }
        public CharacterType character { get; set; }

        public RegisterDTO(string username, string password, string user_nickname, CharacterType character)
        {
            this.password = password;
            this.username = username;
            this.user_nickname = user_nickname;
            this.character = character;
        }
    }
}