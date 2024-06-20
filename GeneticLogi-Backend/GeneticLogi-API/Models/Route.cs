namespace GeneticLogi_Backend.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public int OrderDeliveryId { get; set; }
        public float TotalCost { get; set; }

        // Relationships many-to-many
        public List<RouteDelivery> RouteDelivery { get; } = [];
    }
}
