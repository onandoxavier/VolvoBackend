using System.Linq.Expressions;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Queries;
using Volvo.API.Domain.Models.Results;

namespace Volvo.API.Domain.Contracts.Services
{
    public interface IBaseService<T, TType> where T : EntityBase<TType>
    {
        Task<Dto?> Get<Dto>(Search<T, TType> search, CancellationToken ct = default);
        Task<T?> GetById(TType id, CancellationToken ct = default);
        Task<PagedResult<Dto>> GetPaged<Dto>(Search<T, TType> search, CancellationToken ct = default);
        Task<IList<T>> GetAll(CancellationToken ct = default, Expression<Func<T, bool>>? Expression = null);
        Task Add(T entity, CancellationToken ct = default);
    }
}
