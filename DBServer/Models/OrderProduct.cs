namespace DBServer.Models
{
    public class OrderProduct
    {
        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
