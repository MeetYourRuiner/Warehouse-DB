using DBClient.Models.Attributes;
using System;
using System.Collections.Generic;

namespace DBClient.Models
{
    public class Shipment
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Дата")]
        public DateTime Date { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long OrderId { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Заказ")]
        public Order Order { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long EmployeeId { get; set; }
        [RelatedEntity]
        [System.ComponentModel.DisplayName("Сотрудник")]
        public Employee Employee { get; set; }

        public List<ShipmentProduct> ShipmentProducts { get; set; }

        public override string ToString()
        {
            return this.Id.ToString();
        }
        public string Display { get => this.ToString(); }
    }
}
