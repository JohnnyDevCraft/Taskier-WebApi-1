﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taskier.Core.DataLayer;
using Taskier.Data.Entities;
using Taskier.Domain.ServiceModel;

namespace Taskier.Data.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly TaskierContext db;
        private readonly IMapper mapper;

        public TaskRepo(TaskierContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<TaskSm> CreateTaskAsync(TaskSm task)
        {
            var entity = mapper.Map<TaskItem>(task);
            await db.TaskItems.AddAsync(entity);
            await db.SaveChangesAsync();
            return mapper.Map<TaskSm>(entity);
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await db.TaskItems.FindAsync(id);
            db.TaskItems.Remove(task);
            await db.SaveChangesAsync();
        }

        public async Task<TaskSm> FindTaskAsync(int id)
        {
            var item =  await db.TaskItems.FindAsync(id);
            return mapper.Map<TaskSm>(item);
        }

        public async Task<IList<TaskSm>> GetActiveTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            var items = db.TaskItems.Where(item => item.AssignedTo == user && !item.Completed);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var descending = desc ? " descending" : string.Empty;
                items = items.OrderBy($"{orderBy}{descending}");
            }

            if (page > 0 && count > 0)
            {
                items = items.Skip((page - 1) * count).Take(count);
            }

            var records = await items.ToListAsync();
            return records.Select((arg) => mapper.Map<TaskSm>(arg)).ToList();
        }

        public async Task<IList<TaskSm>> GetAllTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            var items = db.TaskItems.Where(item => item.AssignedTo == user);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var descending = desc ? " descending" : string.Empty;
                items = items.OrderBy($"{orderBy}{descending}");
            }

            if (page > 0 && count > 0)
            {
                items = items.Skip((page - 1) * count).Take(count);
            }

            var records = await items.ToListAsync();
            return records.Select((arg) => mapper.Map<TaskSm>(arg)).ToList();
        }

        public async Task PatchTaskAsync(int id, string prop, object value)
        {
            var task = await db.TaskItems.FindAsync(id);
            task.GetType().GetProperty(prop).SetValue(task, value);
            db.Entry(task).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<TaskSm> UpdateTaskAsync(TaskSm task)
        {
            var entry = db.Attach(mapper.Map<TaskItem>(task));
            entry.State = EntityState.Modified;
            await db.SaveChangesAsync();
            return mapper.Map<TaskSm>(entry.Entity);
        }
    }
}
