namespace CCL.Security.Identity
{
    public class Director : User
    {
        public Director(int userId, string name, int weatherId) : base(userId, name, weatherId, nameof(Director))
        {
        }
    }
}