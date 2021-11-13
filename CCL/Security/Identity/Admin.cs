namespace CCL.Security.Identity
{
    public class Admin : User
    {
        public Admin(int userId, string name, int weatherId) : base(userId, name, weatherId, nameof(Admin))
        {
        }
    }
}