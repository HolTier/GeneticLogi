namespace GeneticLogi_Backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int CityId { get; set; }
        public required string Status { get; set; } = "Pending";

        // Relationships many-to-many
        public List<OrderDelivery> OrderDelivery { get; } = [];
    }
}
