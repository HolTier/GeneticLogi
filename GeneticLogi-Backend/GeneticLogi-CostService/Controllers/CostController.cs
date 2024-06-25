using GeneticLogi_CostService.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeneticLogi_CostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : Controller
    {
        private readonly ICostService _costService;

        public CostController(ICostService costService)
        {
            _costService = costService;
        }

        [HttpPost("CalculateCost")]
        public async Task<IActionResult> CalculateCost([FromBody] int maxIterations = 1000)
        {
            var cost = await _costService.RunAlgorithmAsync(maxIterations);
            return Ok(cost);
        }
    }
}
