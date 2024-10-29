namespace Volvo.API.Domain.Models.Results
{
    public class TruckListResult
    {
        public Guid Id { get; set; }
        public string Chassis { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Plan { get; set; } = string.Empty;
    }
}
