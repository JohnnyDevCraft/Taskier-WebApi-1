using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskier.Domain.ViewModel.Request.TaskController;
using Taskier.Domain.ViewModel.Response;

namespace Taskier.Core.ServiceLayer
{
    public interface ITaskService
    {
        Task<TaskierTask> FindTaskAsync(int id);
        Task<IList<TaskierTask>> GetAllTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<IList<TaskierTask>> GetActiveTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<TaskierTask> UpdateTaskAsync(TaskierTask task);
        Task<TaskierTask> CreateTaskAsync(CreateTaskRequest task);
        Task PatchTaskAsync(int id, string prop, object value);
        Task DeleteTaskAsync(int Id);
    }
}
