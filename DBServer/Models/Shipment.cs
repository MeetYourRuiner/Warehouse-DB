using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class Shipment
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать дату")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Требуется указать заказ")]
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public List<ShipmentProduct> ShipmentProducts { get; set; }
    }
}
