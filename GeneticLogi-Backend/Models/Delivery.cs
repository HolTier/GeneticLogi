namespace GeneticLogi_Backend.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StartCityId { get; set; }
        public int EndCityId { get; set; }
        public required string Status { get; set; } = "Pending";

        // Relationships many-to-many
        public List<OrderDelivery> OrderDelivery { get; } = [];
        public List<Route> Route { get; } = [];
    }
}
