using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Taskier.Core.DataLayer;
using Taskier.Core.ServiceLayer;
using Taskier.Domain.ServiceModel;
using Taskier.Domain.ViewModel.Response;

namespace Taskier.Services
{
    class SubTaskService : ISubTaskService
    {
        private readonly IRepoFactory repoFactory;
        private readonly IMapper mapper;

        public SubTaskService(IRepoFactory repoFactory, IMapper mapper)
        {
            this.repoFactory = repoFactory;
            this.mapper = mapper;
        }
        public async Task<TaskierSubTask> CreateSubTaskAsync(TaskierSubTask task)
        {
            var result = await repoFactory.GetSubTaskRepo().CreateSubTaskAsync(mapper.Map<SubTaskSm>(task));
            return mapper.Map<TaskierSubTask>(result);
        }

        public Task DeleteSubTaskAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskierSubTask> FindSubTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TaskierSubTask>> GetActiveSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TaskierSubTask>> GetActiveSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TaskierSubTask>> GetAllSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TaskierSubTask>> GetAllSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            throw new NotImplementedException();
        }

        public Task PatchSubTaskAsync(int id, string prop, object value)
        {
            throw new NotImplementedException();
        }

        public Task<TaskierSubTask> UpdateSubTaskAsync(TaskierSubTask task)
        {
            throw new NotImplementedException();
        }
    }
}
