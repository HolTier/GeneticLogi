using GeneticLogi_Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeneticLogi_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public UserController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Take all users
            var users = await _authorizationService.GetAllUsersAsync();

            return Ok(users);
        }
    }
}
