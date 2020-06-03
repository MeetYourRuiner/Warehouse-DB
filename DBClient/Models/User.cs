using DBClient.Models.Attributes;
using System;

namespace DBClient.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public long? EmployeeId { get; set; }
        [RelatedEntity]
        public Employee Employee { get; set; }
        public UserPermissions Permissions { get; set; }

        public override string ToString()
        {
            return this.Login;
        }
        public string Display { get => this.ToString(); }
    }

    [Flags]
    public enum UserPermissions : short
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        ManageEmployees = 8,
        ManageUsers = 16
    }
}
