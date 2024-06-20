using GeneticLogi_Backend.Data;
using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User?> GetUserByIdAsync(int id)
        {
            return _userRepository.GetByIdAsync(id);
        }
    }
}
