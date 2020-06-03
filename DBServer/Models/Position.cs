using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class Position
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать название")]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Employee> Employees { get; set; }
    }
}
