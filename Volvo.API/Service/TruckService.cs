using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Contracts.Services;
using Volvo.API.Domain.Contracts.Transactions;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Commands;
using Volvo.API.Utils.Exceptions;

namespace Volvo.API.Service
{
    public class TruckService : BaseService<Truck, Guid>, ITruckService
    {
        private readonly ITruckRepository _truckRepository;
        public TruckService(ITruckRepository truckRepository, IUnitOfWork unitOfWork)
            : base(truckRepository, unitOfWork)
        {
            _truckRepository = truckRepository;
        }

        public async Task<Truck> CreateTruck(CreateTruckCommand command, CancellationToken ct = default)
        {
            var truck = new Truck(command);

            var hasChassiAlreadyRegistered = await _truckRepository.HasAny(
                expression: x => x.Chassis.Value == truck.Chassis.Value && !x.Deleted, ct);
            if (hasChassiAlreadyRegistered) throw new BusinessException("Chassi ja cadastrado");

            await _truckRepository.Add(truck, ct);

            await Commit(ct);

            return truck;
        }

        public async Task<Truck> UpdateTruck(UpdateTruckCommand command, CancellationToken ct = default)
        {
            var truck = await _truckRepository.GetById(command.Id, ct);

            if (truck == null) throw new EntityNotFoundException("Caminhão não encontrado.");

            truck.Update(command);

            var hasChassiAlreadyRegistered = await _truckRepository.HasAny(
                expression: x => x.Chassis.Value == truck.Chassis.Value && x.Id != truck.Id && !x.Deleted, ct);
            if (hasChassiAlreadyRegistered) throw new BusinessException("Chassi ja cadastrado");

            await Commit(ct);

            return truck;
        }

        public async Task DeleteTruck(Guid id, CancellationToken ct = default)
        {
            var truck = await _truckRepository.GetById(id, ct);

            if (truck == null) throw new EntityNotFoundException("Caminhão não encontrado.");

            truck.OnDelete();

            await Commit(ct);
        }
    }
}
