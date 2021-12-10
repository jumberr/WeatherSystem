namespace CCL.Security.Identity
{
    public class Director : Person
    {
        public Director(int userId, string username, int weatherId) : base(userId, username, weatherId, nameof(Director))
        {
        }
        
        public override string Register()
        {
            Username = $"{Username}{UserId}";
            Password = $"{nameof(Director)}";
            return Username + Password;
        }

        public override string Login()
        {
            return $"Logged in as {nameof(Director)}";
        }

        public override string WatchTutorial()
        {
            return $"Watched tutorial for {nameof(Director)}";
        }
    }
}