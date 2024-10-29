using Volvo.API.Domain.Models.Enum;

namespace Volvo.API.Domain.Models.Results
{
    public class TruckResult
    {
        public Guid Id { get; set; }
        public string Chassis { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Model { get; set; } = string.Empty;
        public EModelType ModelId { get; set; } = EModelType.None;
        public string Plan { get; set; } = string.Empty;
        public EPlan PlanId { get; set; } = EPlan.None;
        public string Color { get; set; } = string.Empty;
    }
}
