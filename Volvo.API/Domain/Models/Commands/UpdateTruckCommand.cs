using Volvo.API.Domain.Models.Enum;

namespace Volvo.API.Domain.Models.Commands
{
    public class UpdateTruckCommand
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Chassis { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public EModelType Model { get; set; }
        public EPlan Plan { get; set; }
    }
}
