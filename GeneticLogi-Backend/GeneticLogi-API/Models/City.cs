namespace GeneticLogi_Backend.Models
{
    public class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
