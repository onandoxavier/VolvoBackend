using Volvo.API.Domain.Models.Enum;

namespace Volvo.API.Domain.Models.Commands
{
    public class CreateTruckCommand
    {
        public int Year { get; set; }
        public string Chassis { get; set; } = string.Empty;
        public string Color { get; set; }
        public EModelType Model { get; set; }
        public EPlan Plan { get; set; }
    }
}
