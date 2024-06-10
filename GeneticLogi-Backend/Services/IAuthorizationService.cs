using GeneticLogi_Backend.DTOs;
using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Services
{
    public interface IAuthorizationService
    {
        public Task<bool> LoginUserAsync(LoginDto login);
        public Task<bool> RegisterUserAsync(RegistrationDto registration);
        public Task<IEnumerable<User>> GetAllUsersAsync();
        public Task<User?> GetUserByIdAsync(int id);
    }
}
