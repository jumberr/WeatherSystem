namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, int weatherId, string userType)
        {
            UserId = userId;
            Name = name;
            WeatherId = weatherId;
            UserType = userType;
        }

        public int UserId { get; }
        public string Name { get; }
        public int WeatherId { get; }
        protected string UserType { get; }
    }
}