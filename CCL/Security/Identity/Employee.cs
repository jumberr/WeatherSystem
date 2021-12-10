namespace CCL.Security.Identity
{
    public class Employee : Person
    {
        public Employee(int userId, string username, int weatherId) : base(userId, username, weatherId, nameof(Employee))
        {
        }
        
        public override string Register()
        {
            Username = $"{Username}{UserId}";
            Password = $"{nameof(Employee)}";
            return Username + Password;
        }

        public override string Login()
        {
            return $"Logged in as {nameof(Employee)}";
        }

        public override string WatchTutorial()
        {
            return $"Watched tutorial for {nameof(Employee)}";
        }
    }
}