using System;
namespace Taskier.Domain.ViewModel.Request.TaskController
{
    public class CreateTaskRequest
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssignedTo { get; set; }
    }
}
