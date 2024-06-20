namespace GeneticLogi_Backend.Models
{
    public class Package
    {
        public int Id { get; set; }
        public required string Name { get; set; } 
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
    }
}
