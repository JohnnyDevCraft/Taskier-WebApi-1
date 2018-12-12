using System;
using System.Collections.Generic;

namespace Taskier.Domain.ServiceModel
{
    public class TaskSm
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssignedTo { get; set; }

        public IList<SubTaskSm> SubTasks { get; set; }
    }
}
