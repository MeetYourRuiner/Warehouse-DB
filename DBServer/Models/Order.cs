using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DBServer.Models
{
    public class Order
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Требуется указать дату")]
        public DateTime Date { get; set; }
        public bool IsComplete { get; set; }

        [Required(ErrorMessage = "Требуется указать заказчика")]
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Shipment> Shipments { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
    }
}
