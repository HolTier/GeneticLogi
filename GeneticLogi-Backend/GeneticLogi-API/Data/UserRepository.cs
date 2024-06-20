using GeneticLogi_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneticLogi_Backend.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GeneticLogiDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByLoginAndPasswordAsync(string login, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login && u.Password == password);
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
    }
}
