using DBClient.Models.Attributes;

namespace DBClient.Models
{
    public class OrderProduct
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }

        [System.ComponentModel.DisplayName("ИД")]
        public long ProductId { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Товар")]
        public Product Product { get; set; }

        [System.ComponentModel.DisplayName("Количество")]
        public double Quantity { get; set; }
    }
}
