namespace Module.Core.Data
{
    public class ResetPasswordRequest
    {
        public string ForgotPasswordToken { get; set; }
        public string Password { get; set; }
    }
}
