namespace Volvo.API.Domain.Models.Results
{
    public class EnumResult
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public EnumResult(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
