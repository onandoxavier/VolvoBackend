namespace Volvo.API.Domain.Models.Results
{
    public class GetFiltersResult
    {
        public List<EnumResult> Models { get; set; } = [];
        public List<EnumResult> Plans { get; set; } = [];
    }
}
