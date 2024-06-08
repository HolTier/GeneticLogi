namespace GeneticLogi_Backend.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public float MaxWeight { get; set; }
        public float MaxHeight { get; set; }
        public float MaxWidth { get; set; }
        public float MaxLength { get; set; }
    }
}
