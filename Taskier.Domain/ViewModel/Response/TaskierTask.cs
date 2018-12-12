using System;
using System.Collections.Generic;

namespace Taskier.Domain.ViewModel.Response
{
    public class TaskierTask
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssignedTo { get; set; }
        public bool Completed { get; set; }

        public IList<TaskierSubTask> SubTasks { get; set; }
    }
}
