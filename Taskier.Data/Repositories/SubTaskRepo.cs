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
    public class SubTaskRepo: ISubTaskRepo
    {
        private readonly IMapper mapper;
        private readonly TaskierContext db;

        public SubTaskRepo(IMapper mapper, TaskierContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<SubTaskSm> CreateSubTaskAsync(SubTaskSm task)
        {
            var entity = mapper.Map<SubTaskItem>(task);
            await db.SubTaskItems.AddAsync(entity);
            await db.SaveChangesAsync();
            return mapper.Map<SubTaskSm>(entity);
        }

        public async Task DeleteSubTaskAsync(int Id)
        {
            var item = await db.SubTaskItems.FindAsync(Id);
            db.SubTaskItems.Remove(item);
            await db.SaveChangesAsync();
        }

        public async Task<SubTaskSm> FindSubTaskAsync(int id)
        {
            var entity = await db.SubTaskItems.FindAsync(id);
            return mapper.Map<SubTaskSm>(entity);
        }

        public async Task<IList<SubTaskSm>> GetActiveSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc)
        {
            var query = db.SubTaskItems.Where(item => item.TaskItemId == taskId && !item.Complete);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var descending = desc ? " descending" : string.Empty;
                query = query.OrderBy($"{orderBy}{descending}");
            }

            if (page > 0 && count > 0)
            {
                query = query.Skip((page - 1) * count).Take(count);
            }

            var entities = await query.ToListAsync();
            return entities.Select((arg) => mapper.Map<SubTaskSm>(arg)).ToList();
        }

        public async Task<IList<SubTaskSm>> GetActiveSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            var query = db.SubTaskItems.Where(item => item.AssignedTo == user && !item.Complete);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var descending = desc ? " descending" : string.Empty;
                query = query.OrderBy($"{orderBy}{descending}");
            }

            if (page > 0 && count > 0)
            {
                query = query.Skip((page - 1) * count).Take(count);
            }

            var entities = await query.ToListAsync();
            return entities.Select((arg) => mapper.Map<SubTaskSm>(arg)).ToList();
        }

        public async Task<IList<SubTaskSm>> GetAllSubTasksForTaskAsync(int taskId, int page, int count, string orderBy, bool desc)
        {
            var query = db.SubTaskItems.Where(item => item.TaskItemId == taskId);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var descending = desc ? " descending" : string.Empty;
                query = query.OrderBy($"{orderBy}{descending}");
            }

            if (page > 0 && count > 0)
            {
                query = query.Skip((page - 1) * count).Take(count);
            }

            var entities = await query.ToListAsync();
            return entities.Select((arg) => mapper.Map<SubTaskSm>(arg)).ToList();
        }

        public async Task<IList<SubTaskSm>> GetAllSubTasksForUserAsync(string user, int page, int count, string orderBy, bool desc)
        {
            var query = db.SubTaskItems.Where(item => item.AssignedTo == user && !item.Complete);

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                var descending = desc ? " descending" : string.Empty;
                query = query.OrderBy($"{orderBy}{descending}");
            }

            if (page > 0 && count > 0)
            {
                query = query.Skip((page - 1) * count).Take(count);
            }

            var entities = await query.ToListAsync();
            return entities.Select((arg) => mapper.Map<SubTaskSm>(arg)).ToList();
        }

        public async Task PatchSubTaskAsync(int id, string prop, object value)
        {
            var entity = await db.SubTaskItems.FindAsync(id);
            entity.GetType().GetProperty(prop).SetValue(entity, value);
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<SubTaskSm> UpdateSubTaskAsync(SubTaskSm task)
        {
            if (db.SubTaskItems.Any(item => item.Id == task.Id))
            {
                var entity = db.Attach(mapper.Map<SubTaskItem>(task));
                entity.State = EntityState.Modified;
                await db.SaveChangesAsync();
                return mapper.Map<SubTaskSm>(entity);
            }
            else
            {
                throw new ArgumentOutOfRangeException("SubTask does not exist");
            }

        }
    }
}
