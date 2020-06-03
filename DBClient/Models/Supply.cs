using DBClient.Models.Attributes;
using System;
using System.Collections.Generic;

namespace DBClient.Models
{
    public class Supply
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Дата")]
        public DateTime Date { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long SupplierId { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Поставщик")]
        public Supplier Supplier { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long EmployeeId { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Сотрудник")]
        public Employee Employee { get; set; }

        public List<SupplyProduct> SupplyProducts { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Supplier} - {Date.ToShortDateString()}";
        }
        public string Display { get => this.ToString(); }
    }
}
