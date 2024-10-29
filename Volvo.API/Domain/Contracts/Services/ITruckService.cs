using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Commands;

namespace Volvo.API.Domain.Contracts.Services
{
    public interface ITruckService : IBaseService<Truck, Guid>
    {
        Task<Truck> CreateTruck(CreateTruckCommand command, CancellationToken ct = default);
        Task<Truck> UpdateTruck(UpdateTruckCommand command, CancellationToken ct = default);
        Task DeleteTruck(Guid id, CancellationToken ct = default);
    }
}
