using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskier.Domain.ServiceModel;

namespace Taskier.Core.DataLayer
{
    public interface ISubTaskRepo
    {
        Task<SubTaskSm> FindSubTaskAsync(int id);
        Task<IList<SubTaskSm>> GetAllSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<IList<SubTaskSm>> GetActiveSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc);
        Task<IList<SubTaskSm>> GetAllSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc);
        Task<IList<SubTaskSm>> GetActiveSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc);
        Task<SubTaskSm> UpdateSubTaskAsync(SubTaskSm task);
        Task<SubTaskSm> CreateSubTaskAsync(SubTaskSm task);
        Task PatchSubTaskAsync(int id, string prop, object value);
        Task DeleteSubTaskAsync(int Id);
    }
}
