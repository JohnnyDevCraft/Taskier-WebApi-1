using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Taskier.Core.DataLayer;
using Taskier.Core.ServiceLayer;
using Taskier.Domain.ServiceModel;
using Taskier.Domain.ViewModel.Request.TaskController;
using Taskier.Domain.ViewModel.Response;

namespace Taskier.Services
{
    public class TaskService: ITaskService
    {
        private readonly IMapper mapper;
        private readonly ITaskRepo taskRepo;

        public TaskService(IRepoFactory repoFactory, IMapper mapper)
        {
            this.mapper = mapper;
            this.taskRepo = repoFactory.GetTaskRepo();
        }

        public async Task<TaskierTask> CreateTaskAsync(CreateTaskRequest task)
        {
            var model = mapper.Map<TaskSm>(task);
            var result = await taskRepo.CreateTaskAsync(model);
            return mapper.Map<TaskierTask>(result);
        }

        public async Task DeleteTaskAsync(int Id)
        {
            await taskRepo.DeleteTaskAsync(Id);
        }

        public async Task<TaskierTask> FindTaskAsync(int id)
        {
            var result = await taskRepo.FindTaskAsync(id);
            return mapper.Map<TaskierTask>(result);
        }

        public async Task<IList<TaskierTask>> GetActiveTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            var result = await taskRepo.GetActiveTasksForUserAsync(user, page, count, orderBy, desc);
            return result.Select(x => mapper.Map<TaskierTask>(x)).ToList();
        }

        public async Task<IList<TaskierTask>> GetAllTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            var result = await taskRepo.GetAllTasksForUserAsync(user, page, count, orderBy, desc);
            return result.Select(x => mapper.Map<TaskierTask>(x)).ToList();
        }

        public async Task PatchTaskAsync(int id, string prop, object value)
        {
            await taskRepo.PatchTaskAsync(id, prop, value);
        }

        public async Task<TaskierTask> UpdateTaskAsync(TaskierTask task)
        {
            var result = await taskRepo.UpdateTaskAsync(mapper.Map<TaskSm>(task));
            return mapper.Map<TaskierTask>(result);
        }
    }
}
