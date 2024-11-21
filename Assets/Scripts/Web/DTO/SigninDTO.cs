namespace Web.DTO
{
    public class SigninDTO : DTO
    {
        public string userid { get; set; }
        public string password { get; set; }
        public string username { get; set; }

        public SigninDTO(string userid, string password, string username)
        {
            this.userid = userid;
            this.password = password;
            this.username = username;
        }
    }

}