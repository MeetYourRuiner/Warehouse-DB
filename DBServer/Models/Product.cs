using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBServer.Models
{
	public class Product
	{
		public long Id { get; set; }
		[Required(ErrorMessage = "Требуется указать название")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Требуется указать цену")]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Требуется указать НДС")]
		[Column(TypeName = "decimal(2, 2)")]
		public decimal VAT { get; set; }

		public long? UnitId { get; set; }
		public Unit Unit { get; set; }

		public long? CategoryId { get; set; }
		public Category Category { get; set; }

		[NotMapped]
		public double Quantity { get; set; }

		[JsonIgnore]
		public List<OrderProduct> OrderProducts { get; set; }
		[JsonIgnore]
		public List<SupplyProduct> SupplyProducts { get; set; }
		[JsonIgnore]
		public List<ShipmentProduct> ShipmentProducts { get; set; }
	}
}
