using AutoMapper;
using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Entities;

namespace Volvo.API.Data.Repositories
{
    public class TruckRepository : Repository<Truck, Guid>, ITruckRepository
    {
        public TruckRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
