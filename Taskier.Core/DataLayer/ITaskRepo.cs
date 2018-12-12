using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskier.Domain.ServiceModel;

namespace Taskier.Core.DataLayer
{
    public interface ITaskRepo
    {
        Task<TaskSm> FindTask(int id);
        Task<IList<TaskSm>> GetAllTasksForUser(string user, int page, int count, string orderBy, bool desc);
        Task<IList<TaskSm>> GetActiveTasksForUser(string user, int page, int count, string orderBy, bool desc);
        Task<TaskSm> UpdateTask(TaskSm task);
        Task PatchTask(int id, string prop, object value);
        Task DeleteTask(int Id);
    }
}
