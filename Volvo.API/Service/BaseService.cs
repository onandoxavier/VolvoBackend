using System.Linq.Expressions;
using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Contracts.Services;
using Volvo.API.Domain.Contracts.Transactions;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Queries;
using Volvo.API.Domain.Models.Results;

namespace Volvo.API.Service
{
    public class BaseService<T, TType> : IBaseService<T, TType> where T : EntityBase<TType>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T, TType> _repository;
        public BaseService(IRepository<T, TType> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<int> Commit(CancellationToken ct = default)
        {
            return await _unitOfWork.Commit(ct);
        }
        public async Task<T?> GetById(TType id, CancellationToken ct = default)
        {
            return await _repository.GetById(id, ct);
        }
        public async Task<Dto?> Get<Dto>(Search<T, TType> search, CancellationToken ct = default)
        {
            var result = await _repository.Get<Dto>(search, ct);
            return result;
        }
        public async Task<IList<T>> GetAll(CancellationToken ct = default, Expression<Func<T, bool>>? expression = null)
        {
            var result = await _repository.GetAll(ct, expression);
            return result;
        }
        public async Task<PagedResult<Dto>> GetPaged<Dto>(Search<T, TType> search, CancellationToken ct = default)
        {
            var result = await _repository.GetPaged<Dto>(search, ct);
            return result;
        }
        public async Task Add(T entity, CancellationToken ct = default)
        {
            await _repository.Add(entity, ct);
        }
    }
}
