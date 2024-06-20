namespace GeneticLogi_Backend.Models
{
    public class RouteStop
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int CityId { get; set; }
        public int StopOrder { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public float TravelTime { get; set; }
        public float Distance { get; set; }
    }
}
