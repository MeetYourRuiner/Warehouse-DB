using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBServer.Models
{
    public class User
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Требуется указать пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DefaultValue(0)]
        public UserPermissions Permissions { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
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
