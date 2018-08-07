namespace SA.Application.Account
{
    public class AuthResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Language { get; set; }
        public bool IsDealer { get; set; }
        public string Error { get; set; }

    }
}
