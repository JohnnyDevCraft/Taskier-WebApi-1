using System;
namespace Taskier.Core.ServiceLayer
{
    public interface IServiceFactory
    {
        ITaskService GetTaskService();
        ISubTaskService GetSubTaskService();
    }
}
