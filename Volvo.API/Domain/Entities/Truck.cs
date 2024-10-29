using FluentValidation.Results;
using Volvo.API.Domain.Models.Commands;
using Volvo.API.Domain.Models.Enum;
using Volvo.API.Domain.Models.Validations;
using Volvo.API.Domain.Models.ValueObjects;
using Volvo.API.Utils.Exceptions;

namespace Volvo.API.Domain.Entities
{
    public class Truck : EntityBase<Guid>
    {
        public Chassis? Chassis { get; set; }
        public int Year { get; set; }
        public EModelType ModelType { get; private set; }
        public ColorObj Color { get; private set; }
        public EPlan Plan { get; private set; }

        public Truck() { }
        public Truck(CreateTruckCommand command)
        {
            GenereteId();

            Chassis = new Chassis(command.Chassis);
            Year = command.Year;
            ModelType = command.Model;
            Color = new ColorObj(command.Color);
            Plan = command.Plan;

            IsValid();
        }

        public void Update(UpdateTruckCommand command)
        {
            OnUpdate();
            Chassis = new Chassis(command.Chassis);
            Year = command.Year;
            ModelType = command.Model;
            Color = new ColorObj(command.Color);
            Plan = command.Plan;

            IsValid();
        }

        public override bool IsValid()
        {
            ValidationResult = new TruckValidation().Validate(this);
            if (!ValidationResult.IsValid)
            {
                var errors = ValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
                throw new EntityValidationException(string.Join(";", errors));
            }

            return true;
        }

        // Contrutor usado para o seed
        public Truck(Guid id, int year, EModelType model, EPlan plan)
        {
            Id = id;
            CreatedAt = DateTimeOffset.Now;
            Year = year;
            ModelType = model;
            Plan = plan;
        }
    }
}
