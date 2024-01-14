using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repos.Interfaces;

namespace SistemaDeTarefas.Repos
{
    public class TaskRepo : ITaskRepo
    {
        private readonly SistemaDeTarefasDBContext _dbContext;
        public TaskRepo(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<TaskModel> AddTaskById(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await GetTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"Task by ID: {id} not found in database");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<TaskModel> UpdateTaskById(TaskModel task, int id)
        {
            TaskModel taskById = await GetTaskById(id);

            if (taskById == null)
            {
                throw new Exception($"User by ID: {id} not found in database");
            }
            if (task.Name is not null) { taskById.Name = task.Name; }

            if (task.Description is not null) { taskById.Description = task.Description; }

            if (task.Status != taskById.Status) { taskById.Status = task.Status; }

            if (task.User is not null) { taskById.User = task.User; }


            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;

        }
    }
}