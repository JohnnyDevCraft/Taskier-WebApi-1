using System;
using AutoMapper;
using Taskier.Core.DataLayer;
using Taskier.Core.ServiceLayer;

namespace Taskier.Services
{
    public class ServiceFactory: IServiceFactory
    {
        private readonly IMapper mapper;
        private readonly IRepoFactory repoFactory;

        public ServiceFactory(IMapper mapper, IRepoFactory repoFactory)
        {
            this.mapper = mapper;
            this.repoFactory = repoFactory;
        }

        public ISubTaskService GetSubTaskService()
        {
            throw new NotImplementedException();
        }

        public ITaskService GetTaskService()
        {
            return new TaskService(repoFactory, mapper);
        }
    }
}
