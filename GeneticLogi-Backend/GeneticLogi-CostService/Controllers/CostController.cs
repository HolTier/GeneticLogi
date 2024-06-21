using Microsoft.AspNetCore.Mvc;

namespace GeneticLogi_CostService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
