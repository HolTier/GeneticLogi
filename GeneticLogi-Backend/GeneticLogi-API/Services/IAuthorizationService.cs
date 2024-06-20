using GeneticLogi_Backend.DTOs;
using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Services
{
    public interface IAuthorizationService
    {
        public Task<User?> LoginUserAsync(LoginDto login);
        public Task<bool> RegisterUserAsync(RegistrationDto registration);
        public Task<bool> LogoutUserAsync();
    }
}
