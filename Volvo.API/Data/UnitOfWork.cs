﻿using AutoMapper;
using Volvo.API.Data.Repositories;
using Volvo.API.Domain.Contracts.Repositories;
using Volvo.API.Domain.Contracts.Transactions;
using Volvo.API.Domain.Entities;

namespace Volvo.API.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private bool _disposed;
        public UnitOfWork(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Commit(CancellationToken ct = default)
        {
            return await _dbContext.SaveChangesAsync(ct);
        }
        public IRepository<T, TType> Repository<T, TType>() where T : EntityBase<TType>
        {
            return new Repository<T, TType>(_dbContext, _mapper);
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
