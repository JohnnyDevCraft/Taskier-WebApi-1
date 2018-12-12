using System;
using Microsoft.EntityFrameworkCore;
using Taskier.Data.Entities;

namespace Taskier.Data
{
    public class TaskierContext: DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<SubTaskItem> SubTaskItems { get; set; }

        public TaskierContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mb = modelBuilder;

            mb.Entity<TaskItem>(opt =>
            {
                opt.HasKey(t => t.Id);
                opt.HasMany(t => t.SubTasks).WithOne(s => s.TaskItem).HasForeignKey(s => s.TaskItemId);
            });

            mb.Entity<SubTaskItem>(opt =>
            {
                opt.HasKey(t => t.Id);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
