namespace GeneticLogi_Backend.Models
{
    public class OrderDelivery
    {
        public int OrderId { get; set; }
        public int DeliveryId { get; set; }

        public Order Order { get; set; } = null!;
        public Delivery Delivery { get; set; } = null!;
        
    }
}
