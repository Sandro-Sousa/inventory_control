using Entities.Entites;
using Repository.Interfaces;
using Service.DTOs;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User?> CreateUser(UserDTO user)
        {
            var userInsert = new User
            {
                Name = user.Name,
                Email = user.Email,
                Fone = user.Fone
            };

            return await _userRepository.CreateUser(userInsert);
        }

        public async Task<bool> UpdateUser(UserDTO user)
        {
            if (user == null)
            {
                return false;
            }

            var userEntity = await _userRepository.GetUserById(user.IdUser ?? 0);
            if (userEntity == null)
            {
                return false;
            }

            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            userEntity.Fone = user.Fone;

            return await _userRepository.UpdateUser(userEntity);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
