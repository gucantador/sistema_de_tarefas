using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repos.Interfaces
{
    public interface IUserRepo
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> AddUserById(UserModel user);
        Task<UserModel> UpdateUserById(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
