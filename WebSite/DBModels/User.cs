using System;

namespace WebSite.DBModels
{
    public class User
    {
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
}
