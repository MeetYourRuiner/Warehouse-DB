namespace DBServer.Models
{
    public class ShipmentProduct
    {
        public long ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public double Quantity { get; set; }
    }
}
