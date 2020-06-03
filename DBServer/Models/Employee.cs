using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class Employee
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать фамилию")]
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }

        public User User { get; set; }

        public long? PositionId { get; set; }
        public Position Position { get; set; }

        [JsonIgnore]
        public List<Supply> Supplies { get; set; }
        [JsonIgnore]
        public List<Shipment> Shipments { get; set; }
    }
}
