using GeneticLogi_Backend.Models;

namespace GeneticLogi_Backend.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByLoginAndPasswordAsync(string login, string password);
        public Task<User> GetUserByLoginAsync(string login);
    }
}
