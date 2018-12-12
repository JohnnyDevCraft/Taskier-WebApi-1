using System;
namespace Taskier.Domain.ServiceModel
{
    public class SubTaskSm
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public bool Complete { get; set; }
        public string AssignedTo { get; set; }
    }
}
