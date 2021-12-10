namespace CCL.Security.Identity
{
    public class Admin : Person
    {
        public Admin(int userId, string username, int weatherId) : base(userId, username, weatherId, nameof(Admin))
        {
        }
        
        public override string Register()
        {
            Username = $"{Username}{UserId}";
            Password = $"{nameof(Admin)}";
            return Username + Password;
        }

        public override string Login()
        {
            return $"Logged in as {nameof(Admin)}";
        }

        public override string WatchTutorial()
        {
            return $"Watched tutorial for {nameof(Admin)}";
        }
    }
}