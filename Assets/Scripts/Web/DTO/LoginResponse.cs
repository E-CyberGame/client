namespace Web.DTO
{
    public class LoginResponse : DTO
    {
        public string message { get; set; }
        public NameDTO userName { get; set; }
    }
}