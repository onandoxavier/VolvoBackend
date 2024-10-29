using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Entities;

namespace Volvo.API.Domain.Contracts.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken ct = default);
        IRepository<T, TType> Repository<T, TType>() where T : EntityBase<TType>;
    }
}
