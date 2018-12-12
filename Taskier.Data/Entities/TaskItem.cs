using System;
using System.Collections.Generic;

namespace Taskier.Data.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssignedTo { get; set; }
        public IList<SubTaskItem> SubTasks { get; set; }
    }
}
