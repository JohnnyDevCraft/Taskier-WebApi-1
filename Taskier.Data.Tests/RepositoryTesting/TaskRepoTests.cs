using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taskier.Data.Configure;
using Taskier.Data.Entities;
using Taskier.Data.Repositories;

namespace Taskier.Data.Tests.RepositoryTesting
{
    [TestClass]
    public class TaskRepoTests
    {
        private TaskierContext SetupData()
        {
            var coBuilder = new DbContextOptionsBuilder<TaskierContext>();
            coBuilder.UseInMemoryDatabase("TestDb");
            var db = new TaskierContext(coBuilder.Options);

            db.TaskItems.Add(new TaskItem()
            {
                AssignedTo = "bob", Subject = "Something To Do", Description = $"New Desc {Guid.NewGuid()}",
                StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), Completed = false
            });
            
            db.TaskItems.Add(new TaskItem()
            {
                AssignedTo = "bob", Subject = "Something To Do 2", Description = $"New Desc {Guid.NewGuid()}",
                StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), Completed = false
            });
            
            db.TaskItems.Add(new TaskItem()
            {
                AssignedTo = "marc", Subject = "Something To Do 3", Description = $"New Desc {Guid.NewGuid()}",
                StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), Completed = false
            });
            
            db.TaskItems.Add(new TaskItem()
            {
                AssignedTo = "bob", Subject = "Something To Do 4", Description = $"New Desc {Guid.NewGuid()}",
                StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), Completed = false
            });
            
            db.TaskItems.Add(new TaskItem()
            {
                AssignedTo = "janet", Subject = "Something To Do 5", Description = $"New Desc {Guid.NewGuid()}",
                StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(5), Completed = false
            });

            db.SaveChanges();
            
            return db;
        }
        
        private IMapper SetupMapper(Profile profile)
        {
            return new Mapper(new MapperConfiguration(mp => { mp.AddProfile(profile); }));
        }
        
        [TestMethod]
        public void GetActiveTasksForUSerAsync_ShouldReturnAllForUser_WhenNotPaging()
        {
            //Setup
            var db = SetupData();
            var mapper = SetupMapper(new MappingProfile());
            var repo = new TaskRepo(db, mapper);

            //Test
            var results = repo.GetActiveTasksForUserAsync("bob", 0, 0, "", false).Result;
            
            //Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count > 0);
            Assert.IsTrue(results.Any(t =>t.AssignedTo == "bob"));
            Assert.IsFalse(results.Any(t=> t.AssignedTo != "bob"));

        }
    }
}