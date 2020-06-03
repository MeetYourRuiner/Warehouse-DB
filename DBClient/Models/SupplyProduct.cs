using DBClient.Models.Attributes;

namespace DBClient.Models
{
    public class SupplyProduct
    {
        public long SupplyId { get; set; }
        [RelatedEntity]
        public Supply Supply { get; set; }

        [System.ComponentModel.DisplayName("ИД")]
        public long ProductId { get; set; }

        [RelatedEntity]
        [System.ComponentModel.DisplayName("Товар")]
        public Product Product { get; set; }

        [System.ComponentModel.DisplayName("Количество")]
        public double Quantity { get; set; }
    }
}
