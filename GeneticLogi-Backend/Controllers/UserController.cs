using GeneticLogi_Backend.DTOs;
using GeneticLogi_Backend.Models;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Take user by id
            var user = await _authorizationService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            // Validate user
            var isValid = await _authorizationService.LoginUserAsync(login);

            if (isValid)
            {
                return Unauthorized();
            }

            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registration)
        {
            // Register user
            var isRegistered = await _authorizationService.RegisterUserAsync(registration);

            if (!isRegistered)
            {
                return BadRequest("Empty field or login exist");
            }

            return Ok("User registered");
        }
    }
}
