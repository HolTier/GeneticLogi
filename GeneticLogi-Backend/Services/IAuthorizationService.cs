using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Services
{
    public interface IAuthorizationService
    {
        public Task<bool> ValidateUserAsync(string login, string password);
        public Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
