using System.Linq.Expressions;
using Volvo.API.Domain.Entities;
using Volvo.API.Domain.Models.Enum;
using Volvo.API.Utils.Extensions;

namespace Volvo.API.Domain.Models.Queries
{
    public class TruckSearch : Search<Truck, Guid>
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Chassis { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Color { get; set; } = string.Empty;
        public EModelType Model { get; set; } = EModelType.None;
        public EPlan Plan { get; set; } = EPlan.None;

        public TruckSearch() { }
        public TruckSearch(int page, int rows)
        {
            Page = page < 1 ? 1 : page;
            Rows = rows < 1 ? 10 : rows;
        }

        public override Expression<Func<Truck, bool>> CreateExpression(Expression<Func<Truck, bool>>? expression = null)
        {
            // Se a expressão for nula, começa com uma expressão que é sempre verdadeira
            if (expression == null)
                expression = (truck => true);

            if (!IncludeDelete)
                expression = expression.AndAlso(x => !x.Deleted);

            if (Id != Guid.Empty)
                expression = expression.AndAlso(x => x.Id == Id);

            if (Year > 0)
                expression = expression.AndAlso(x => x.Year == Year);

            if (!string.IsNullOrEmpty(Color))
            {
                var color = Color.Replace("#", "");
                expression = expression.AndAlso(x => x.Color.Value == color);
            }

            if (!string.IsNullOrEmpty(Chassis))
            {
                expression = expression.AndAlso(x => x.Chassis.Value.Contains(Chassis));
            }

            if (Model != EModelType.None)
                expression = expression.AndAlso(x => x.ModelType == Model);

            if (Plan != EPlan.None)
                expression = expression.AndAlso(x => x.Plan == Plan);

            return expression;
        }
    }
}
