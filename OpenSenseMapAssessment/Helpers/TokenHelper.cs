namespace OpenSenseMapAssessment.Helpers
{
    public class TokenHelper
    {
        public static string Token { get; set; }
        public static string RefreshToken { get; set; }

        public static bool HasToken => !string.IsNullOrWhiteSpace(Token);

        public static void Clear()
        {
            Token = null;
            RefreshToken = null;
        }

    }
}
