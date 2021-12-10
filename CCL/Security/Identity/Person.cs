namespace CCL.Security.Identity
{
    public abstract class Person
    {
        public Person(int userId, string username, int weatherId, string userType)
        {
            UserId = userId;
            Username = username;
            WeatherId = weatherId;
            UserType = userType;
        }

        public int UserId { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int WeatherId { get; }
        protected string UserType { get; }

        public void CreatePerson(out string register, out string login, out string tutorial)
        {
            register = Register();
            login = Login();
            tutorial = WatchTutorial();
        }

        public abstract string Register();
        public abstract string Login();
        public abstract string WatchTutorial();
        
    }
}