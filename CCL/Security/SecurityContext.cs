using CCL.Security.Identity;

namespace CCL.Security
{
    public static class SecurityContext
    {
        private static Person _person = null;

        public static Person GetUser() => _person;

        public static void SetUser(Person person)
        {
            _person = person;
        }
    }
}