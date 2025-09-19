
using Domain.Models;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task DeleteUser(int id);
        Task<ICollection<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(User user);
    }
}
