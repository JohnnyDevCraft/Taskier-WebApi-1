using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskier.Domain.ViewModel.Response;

namespace Taskier.Core.ServiceLayer
{
    public interface ISubTaskService
    {
        Task<TaskierSubTask> FindSubTaskAsync(int id);
        Task<IList<TaskierSubTask>> GetAllSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<IList<TaskierSubTask>> GetActiveSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<IList<TaskierSubTask>> GetAllSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc);
        Task<IList<TaskierSubTask>> GetActiveSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc);
        Task<TaskierSubTask> UpdateSubTaskAsync(TaskierSubTask task);
        Task<TaskierSubTask> CreateSubTaskAsync(TaskierSubTask task);
        Task PatchSubTaskAsync(int id, string prop, object value);
        Task DeleteSubTaskAsync(int Id);
    }
}
