using System.Linq.Expressions;
using Volvo.API.Domain.Entities;

namespace Volvo.API.Domain.Models.Queries
{
    public abstract class Search<T, TType> where T : EntityBase<TType>
    {
        public int Page { get; set; } = 1;
        public int Rows { get; set; } = 10;
        public bool IncludeDelete { get; set; } = false;
        public bool TrackQuery { get; set; } = true;
        public int SkipPages() => (Page - 1) * Rows;
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy;
        public abstract Expression<Func<T, bool>> CreateExpression(Expression<Func<T, bool>>? expression = null);
    }
}
