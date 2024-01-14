using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repos.Interfaces
{
    public interface ITaskRepo
    {
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> GetTaskById(int id);
        Task<TaskModel> AddTaskById(TaskModel task);
        Task<TaskModel> UpdateTaskById(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}
