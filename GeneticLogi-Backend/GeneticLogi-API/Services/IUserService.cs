using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
    }
}
