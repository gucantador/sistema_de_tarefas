using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repos.Interfaces;

namespace SistemaDeTarefas.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly SistemaDeTarefasDBContext _dbContext;
        public UserRepo(SistemaDeTarefasDBContext sistemaDeTarefasDBContext) 
        {
            _dbContext = sistemaDeTarefasDBContext;
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> AddUserById(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User by ID: {id} not found in database");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<UserModel> UpdateUserById(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User by ID: {id} not found in database");
            }
            if (user.Name is not null) { userById.Name = user.Name; }
            
            if (user.Email is not null) { userById.Email = user.Email; }
            

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;

        }
    }
}
