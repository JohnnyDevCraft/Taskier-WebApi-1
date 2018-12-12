using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskier.Domain.ServiceModel;

namespace Taskier.Core.DataLayer
{
    public interface ISubTaskRepo
    {
        Task<SubTaskSm> FindSubTask(int id);
        Task<IList<SubTaskSm>> GetAllSubTasksForUser(string user, int page, int count, string orderBy, bool desc);
        Task<IList<SubTaskSm>> GetActiveSubTasksForUser(string user, int page, int count, string orderBy, bool desc);
        Task<IList<SubTaskSm>> GetAllSubTasksForTask(int taskId, int page, int count, string orderBy, bool desc);
        Task<IList<SubTaskSm>> GetActiveSubTasksForTask(int taskId, int page, int count, string orderBy, bool desc);
        Task<SubTaskSm> UpdateSubTask(SubTaskSm task);
        Task<bool> PatchSubTask(int id, string prop, object value);
        Task<bool> DeleteSubTask(int Id);
    }
}
