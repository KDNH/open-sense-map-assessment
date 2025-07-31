namespace OpenSenseMapAssessment.Models.User
{
    public class UserRegisterResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public UserRegisterData Data { get; set; }
        public string Token { get; set; }

        public string RefreshToken { get; set; }

    }

    public class UserRegisterData
    {
        public UserRegisterInfo User { get; set; }
    }

    public class UserRegisterInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Language { get; set; } = "en-US";
        public List<string> Boxes { get; set; }
        public bool EmailIsConfirmed { get; set; }
    }
}
