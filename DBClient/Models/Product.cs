using DBClient.Models.Attributes;
using System.Collections.Generic;

namespace DBClient.Models
{
    public class Product
    {
        [IgnoreInForm]
        [System.ComponentModel.DisplayName("ИД")]
        public long Id { get; set; }

        [System.ComponentModel.DisplayName("Название")]
        public string Name { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Категория")]
        public Category Category { get; set; }

        [IgnoreInForm]
        [System.ComponentModel.DisplayName("Количество")]
        public double Quantity { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Единицы")]
        public Unit Unit { get; set; }

        [System.ComponentModel.DisplayName("Цена")]
        public decimal Price { get; set; }

        [System.ComponentModel.DisplayName("НДС")]
        public decimal VAT { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long? CategoryId { get; set; }

        [System.ComponentModel.Browsable(false)]
        public long? UnitId { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
        public List<SupplyProduct> SupplyProducts { get; set; }
        public List<ShipmentProduct> ShipmentProducts { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
        public string Display { get => this.ToString(); }
        public string NameWithId { get => $"{Id} – {Name}"; }
    }
}
