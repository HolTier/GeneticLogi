
using GeneticLogi_Backend.Data;
using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // TODO: Implement hashing for password
        public async Task<bool> ValidateUserAsync(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return await Task.FromResult(false);
            }

            var user = await _userRepository.GetUserByLoginAndPasswordAsync(login, password);

            return user != null;
        }
    }
}
