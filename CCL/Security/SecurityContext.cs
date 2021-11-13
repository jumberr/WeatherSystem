﻿using CCL.Security.Identity;

namespace CCL.Security
{
    public static class SecurityContext
    {
        private static User _user = null;

        public static User GetUser() => _user;

        public static void SetUser(User user)
        {
            _user = user;
        }
    }
}