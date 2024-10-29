using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.API.Domain.Entities
{
    public abstract class EntityBase<T>
    {
        public T Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
        public bool Deleted { get; set; }

        [NotMapped]
        public virtual ValidationResult ValidationResult { get; protected set; }

        public void OnUpdate() => UpdatedAt = DateTimeOffset.Now;
        public void OnDelete()
        {
            OnUpdate();
            Deleted = true;
        }

        public abstract bool IsValid();

        public void GenereteId()
        {
            var propertyValue = GetType().GetProperty("Id");

            if (typeof(T) == typeof(Guid))
            {
                propertyValue.SetValue(this,
                    Guid.NewGuid(),
                    null);
            }
        }
    }
}
