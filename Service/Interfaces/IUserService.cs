using Entities.Entites;
using Service.DTOs;

namespace Repository.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User?> CreateUser(UserDTO user);
        Task<bool> UpdateUser(UserDTO user);
        Task<bool> DeleteUser(int id);
    }
}
