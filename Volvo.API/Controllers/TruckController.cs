using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volvo.API.Domain.Contracts.Services;
using Volvo.API.Domain.Models.Commands;
using Volvo.API.Domain.Models.Enum;
using Volvo.API.Domain.Models.Queries;
using Volvo.API.Domain.Models.Results;
using Volvo.API.Utils.Extensions;

namespace Volvo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<TruckController> _logger;
        private readonly ITruckService _truckService;

        public TruckController(ILogger<TruckController> logger, IMapper mapper, ITruckService truckService)
        {
            _logger = logger;
            _mapper = mapper;
            _truckService = truckService;
        }

        [HttpGet("Filters", Name = "GetFilters")]
        public ActionResult<GetFiltersResult> GetFilters()
        {
            var result = new GetFiltersResult();
            var plans = Enum.GetValues(typeof(EPlan)).Cast<EPlan>().ToList();
            plans.RemoveAll(x => x == EPlan.None);
            plans.ForEach(x => result.Plans.Add(new EnumResult(id: (int)x, description: x.GetDescription())));

            var models = Enum.GetValues(typeof(EModelType)).Cast<EModelType>().ToList();
            models.RemoveAll(x => x == EModelType.None);
            models.ForEach(x => result.Models.Add(new EnumResult(id: (int)x, description: x.GetDescription())));

            return result;
        }

        [HttpGet("{Id}", Name = "GetTruckById")]
        public async Task<ActionResult<TruckResult>> GetTruckById(Guid Id, CancellationToken ct = default)
        {
            var search = new TruckSearch() { Id = Id };
            var result = await _truckService.Get<TruckResult>(search, ct);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("", Name = "GetTrucks")]
        public async Task<ActionResult<PagedResult<TruckListResult>>> GetTrucks(int page = 1, int rows = 5,
            string chassis = "", string color = "", int year = 0,
            EModelType model = EModelType.None, EPlan plan = EPlan.None, CancellationToken ct = default)
        {
            var search = new TruckSearch(page, rows)
            {
                Chassis = chassis,
                Model = model,
                Color = color,
                Year = year,
                Plan = plan,
                OrderBy = source => source.OrderBy(t => t.Year).ThenBy(t => t.Chassis.Value)
            };

            var result = await _truckService.GetPaged<TruckListResult>(search, ct);
            return result;
        }

        [HttpPost(Name = "CreateTruck")]
        public async Task<ActionResult<TruckResult>> CreateTruck(CreateTruckCommand command, CancellationToken ct = default)
        {
            var entity = await _truckService.CreateTruck(command, ct);
            var result = _mapper.Map<TruckResult>(entity);
            return result;
        }

        [HttpPut(Name = "UpdateTruck")]
        public async Task<ActionResult<TruckResult>> UpdateTruck(UpdateTruckCommand command, CancellationToken ct = default)
        {
            var entity = await _truckService.UpdateTruck(command, ct);
            var result = _mapper.Map<TruckResult>(entity);
            return result;
        }

        [HttpDelete("{Id}", Name = "DeleteTruck")]
        public async Task<IActionResult> DeleteTruck(Guid Id, CancellationToken ct = default)
        {
            await _truckService.DeleteTruck(Id, ct);
            return NoContent();
        }
    }
}
