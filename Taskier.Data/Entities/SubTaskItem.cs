using System;
namespace Taskier.Data.Entities
{
    public class SubTaskItem
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public bool Complete { get; set; }
        public string AssignedTo { get; set; }
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }
    }
}
