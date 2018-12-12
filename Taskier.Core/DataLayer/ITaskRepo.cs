using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskier.Domain.ServiceModel;

namespace Taskier.Core.DataLayer
{
    public interface ITaskRepo
    {
        Task<TaskSm> FindTaskAsync(int id);
        Task<IList<TaskSm>> GetAllTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<IList<TaskSm>> GetActiveTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<TaskSm> UpdateTaskAsync(TaskSm task);
        Task<TaskSm> CreateTaskAsync(TaskSm task);
        Task PatchTaskAsync(int id, string prop, object value);
        Task DeleteTaskAsync(int Id);
    }
}
