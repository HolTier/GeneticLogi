namespace GeneticLogi_Backend.Models
{
    public class RouteDelivery
    {
        public int RouteId { get; set; }
        public int DeliveryId { get; set; }

        public Route Route { get; set; } = null!;
        public Delivery Delivery { get; set; } = null!;
    }
}
