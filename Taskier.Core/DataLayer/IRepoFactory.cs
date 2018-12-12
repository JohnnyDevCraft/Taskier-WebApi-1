using System;
namespace Taskier.Core.DataLayer
{
    public interface IRepoFactory
    {
        ITaskRepo GetTaskRepo();
        ISubTaskRepo GetSubTaskRepo();
    }
}
