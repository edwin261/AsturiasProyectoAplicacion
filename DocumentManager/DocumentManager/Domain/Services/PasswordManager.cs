namespace DocumentManager.DesignPatterns.Singleton
{
    public sealed class PasswordManager
    {
        private static readonly PasswordManager _instance = new();
        private const string _password = "Doc123456";

        private PasswordManager() { }

        public static PasswordManager Instance => _instance;

        public bool Validate(string password)
        {
            return password == _password;
        }
    }
}