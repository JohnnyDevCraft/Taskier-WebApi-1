using System;
namespace Taskier.Domain.ViewModel.Response
{
    public class TaskierSubTask
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public bool Complete { get; set; }
        public string AssignedTo { get; set; }
    }
}
