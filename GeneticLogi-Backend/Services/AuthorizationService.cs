using GeneticLogi_Backend.Data;
using GeneticLogi_Backend.DTOs;
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

        public async Task<User?> LoginUserAsync(LoginDto login)
        {
            if (string.IsNullOrEmpty(login.Login) || string.IsNullOrEmpty(login.Password))
            {
                return null;
            }

            var user = await _userRepository.GetUserByLoginAndPasswordAsync(login.Login, login.Password);

            if (user == null)
            {
                return null;
            }

            // Verify password plain text with hashed password
            bool isVerified = BCrypt.Net.BCrypt.Verify(login.Password, user.Password);

            if (isVerified)
            {
                return user;
            }

            return null;
        }

        public async Task<bool> RegisterUserAsync(RegistrationDto registration)
        {
            // Check if fields are empty
            if (string.IsNullOrEmpty(registration.Login) || string.IsNullOrEmpty(registration.Password) || string.IsNullOrEmpty(registration.Email))
            {
                return await Task.FromResult(false);
            }

            // Check if user with this login already exists
            var user = await _userRepository.GetUserByLoginAsync(registration.Login);
            if (user != null)
            {
                return await Task.FromResult(false);
            }

            // Hash password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registration.Password);

            // Create new user
            var newUser = new User
            {
                Login = registration.Login,
                Password = hashedPassword,
                Name = registration.Email
            };

            // Add user to database
            await _userRepository.AddAsync(newUser);

            return await Task.FromResult(true);
        }
    }
}
