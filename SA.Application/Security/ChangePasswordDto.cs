namespace SA.Application.Security
{
    public class ChangePasswordDto
    {
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }
        public string Token { get; set; }
    }
}
