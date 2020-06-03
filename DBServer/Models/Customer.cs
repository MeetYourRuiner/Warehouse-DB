using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Требуется указать имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Требуется указать индекс")]
        [MinLength(6, ErrorMessage = "В индексе требуется указать шестизначное число")]
        [MaxLength(6, ErrorMessage = "В индексе требуется указать шестизначное число")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Требуется указать адрес")]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Требуется указать ИНН")]
        public string INN { get; set; }
        public string KPP { get; set; }

        public string PaymentAccount { get; set; }

        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}
