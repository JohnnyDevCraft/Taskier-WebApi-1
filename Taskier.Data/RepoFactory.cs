using System;
using AutoMapper;
using Taskier.Core.DataLayer;
using Taskier.Data.Repositories;

namespace Taskier.Data
{
    public class RepoFactory: IRepoFactory
    {
        private readonly IMapper mapper;
        private readonly TaskierContext db;

        public RepoFactory(IMapper mapper, TaskierContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public ISubTaskRepo GetSubTaskRepo()
        {
            return new SubTaskRepo(mapper, db);
        }

        public ITaskRepo GetTaskRepo()
        {
            return new TaskRepo(db, mapper);
        }
    }
}
