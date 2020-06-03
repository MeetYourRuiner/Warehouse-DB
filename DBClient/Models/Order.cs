using DBClient.Models.Attributes;
using System;
using System.Collections.Generic;

namespace DBClient.Models
{
    public class Order
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Дата")]
        public DateTime Date { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long CustomerId { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Заказчик")]
        public Customer Customer { get; set; }

        [System.ComponentModel.DisplayName("Выполнен")]
        public bool IsComplete { get; set; }

        public List<Shipment> Shipments { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Customer} - {Date.ToShortDateString()}";
        }
        public string Display { get => this.ToString(); }
    }
}
