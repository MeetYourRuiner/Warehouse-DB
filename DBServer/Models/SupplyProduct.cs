namespace DBServer.Models
{
    public class SupplyProduct
    {
        public long SupplyId { get; set; }
        public Supply Supply { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
