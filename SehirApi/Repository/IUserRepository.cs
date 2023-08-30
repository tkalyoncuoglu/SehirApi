using SehirApi.Models;

namespace SehirApi.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);


    }
}
