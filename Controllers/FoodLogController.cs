using BodyRecomp.Requests.FoodEntry;
using BodyRecomp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BodyRecomp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodLogController : ControllerBase
    {
        private readonly IFoodLogService _foodLogService;

        public FoodLogController(IFoodLogService foodLogService)
        {
            _foodLogService = foodLogService;
        }

        [HttpPost]
        public async Task<IActionResult> LogFood([FromBody] CreateFoodEntryRequest request)
        {
            var entry = await _foodLogService.LogFoodAsync(request);
            return CreatedAtAction(nameof(GetForDate), new { date = entry.LoggedAt.Date }, entry);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> LogFoodBulk([FromBody] List<CreateFoodEntryRequest> requests)
        {
            if (requests == null || !requests.Any())
                return BadRequest("Request list is empty.");

            foreach (var req in requests)
            {
                if (string.IsNullOrWhiteSpace(req.Name))
                    return BadRequest("One or more entries are missing required fields.");
            }

            var result = await _foodLogService.LogFoodBulkAsync(requests);
            return Ok(result);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetForDate(DateTime date)
        {
            var entries = await _foodLogService.GetFoodLogsByDateAsync(date);
            return Ok(entries);
        }
    }
}
