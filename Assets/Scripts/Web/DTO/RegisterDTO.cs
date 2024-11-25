namespace Web.DTO
{
    public class RegisterDTO : DTO
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string userEmail { get; set; }
        public string userNickname { get; set; }

        public RegisterDTO(string userName, string password, string userNickname)
        {
            this.userName = userName;
            this.password = password;
            this.userEmail = "Email@gmail.com";
            this.userNickname = userNickname;
        }
    }
}