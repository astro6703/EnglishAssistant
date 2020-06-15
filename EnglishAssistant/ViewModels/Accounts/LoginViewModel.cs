namespace EnglishAssistant.ViewModels.Accounts
{
    public class LoginViewModel
    {
        public bool IsSuccessfulAttempt { get; set; }

        public string[] ModelErrors { get; set; }

        public string Username { get; set; }
    }
}