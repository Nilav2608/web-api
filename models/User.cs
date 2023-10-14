namespace web_api.models
{
    public class User
    {
        public String Username { get; set; } = string.Empty;

        public String PasswordHash { get; set; }   = String.Empty;
    }
}