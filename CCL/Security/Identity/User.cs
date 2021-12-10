namespace CCL.Security.Identity
{
    public class User : Person
    {
        public User(int userId, string username, int weatherId) : base(userId, username, weatherId, nameof(User))
        {
        }
        
        public override string Register()
        {
            Username = $"{Username}{UserId}";
            Password = $"{nameof(User)}";
            return Username + Password;
        }

        public override string Login()
        {
            return $"Logged in as {nameof(User)}";
        }

        public override string WatchTutorial()
        {
            return $"Watched tutorial for {nameof(User)}";
        }
    }
}