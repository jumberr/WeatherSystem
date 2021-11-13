namespace CCL.Security.Identity
{
    public class Employee : User
    {
        public Employee(int userId, string name, int weatherId) : base(userId, name, weatherId, nameof(Employee))
        {
        }
    }
}