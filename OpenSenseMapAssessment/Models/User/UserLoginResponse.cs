namespace OpenSenseMapAssessment.Models.User
{
    public class UserLoginResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public UserLoginData Data { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }

    public class UserLoginData
    {
        public UserLoginInfo User { get; set; }
    }

    public class UserLoginInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Language { get; set; } = "en-US";
        public List<string> Boxes { get; set; }
        public bool EmailIsConfirmed { get; set; }
    }
}
