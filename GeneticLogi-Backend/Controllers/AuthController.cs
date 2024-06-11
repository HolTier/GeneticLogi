using GeneticLogi_Backend.DTOs;
using GeneticLogi_Backend.Models;
using GeneticLogi_Backend.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeneticLogi_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (login.Login == null || login.Password == null)
            {
                return BadRequest("Empty field");
            }

            // Validate user
            var user = await _authorizationService.LoginUserAsync(login);

            if (user == null)
            {
                return Unauthorized(user);
            }

            // Create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Login),
                new Claim(ClaimTypes.Role, "User")
            };

            // Create identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            // Sign in
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok(user);
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
