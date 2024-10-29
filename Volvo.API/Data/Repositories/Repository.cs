using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Queries;
using Volvo.API.Domain.Models.Results;
namespace Volvo.API.Data.Repositories
{
    public class Repository<T, TType> : IRepository<T, TType> where T : EntityBase<TType>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

            _dbSet = _dbContext.Set<T>();
        }
        public async Task<Dto?> Get<Dto>(Search<T, TType> search, CancellationToken ct = default)
        {
            var entity = _dbSet.Where(search.CreateExpression()).AsNoTrackingWithIdentityResolution();

            var projected = _mapper.ProjectTo<Dto>(entity);
            var result = await projected.FirstOrDefaultAsync(ct);

            return result;
        }
        public async Task<PagedResult<Dto>> GetPaged<Dto>(Search<T, TType> search, CancellationToken ct = default)
        {
            var entity = _dbSet.Where(search.CreateExpression()).AsNoTrackingWithIdentityResolution();

            var total = await entity.CountAsync(ct);

            var ordered = search.OrderBy != null ? search.OrderBy(entity) : entity;
            var paged = ordered.Skip(search.SkipPages()).Take(search.Rows);

            var projected = _mapper.ProjectTo<Dto>(paged);
            var items = await projected.ToListAsync(ct);

            var result = new PagedResult<Dto>(items: items, total: total, page: search.Page, search.Rows);

            return result;
        }
        public async Task<T?> GetById(TType id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(id, ct);
        }
        public async Task<bool> HasAny(Expression<Func<T, bool>> expression, CancellationToken ct = default)
        {
            var result = await _dbSet.AnyAsync(expression, ct);
            return result;
        }
        public async Task<IList<T>> GetAll(CancellationToken ct = default, Expression<Func<T, bool>>? expression = null)
        {
            var result = expression != null ?
                await _dbSet.Where(expression).ToListAsync() :
                await _dbSet.ToListAsync(ct);

            return result;
        }
        public async Task Add(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity, ct);
        }
    }
}
