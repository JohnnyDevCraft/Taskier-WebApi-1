using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taskier.Core.ServiceLayer;
using Taskier.Domain.ViewModel.Request.TaskController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taskier.Api.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly ITaskService _taskService;

        public TaskController(IServiceFactory serviceFactory)
        {
            this._serviceFactory = serviceFactory;
            this._taskService = serviceFactory.GetTaskService();
        }


        // GET: api/tasks
        [HttpGet("/api/tasks/all")]
        public async Task<IActionResult> Get([FromQuery]int page = 0, [FromQuery]int count = 0, [FromQuery]string orderBy = "", [FromQuery]bool desc = true)
        {
            if (page > 0 && count < 1) return BadRequest("Count must be higher than 0 when using paged results.");
            return Ok(await _taskService.GetAllTasksForUserAsync(User.Identity.Name, page, count, orderBy, desc));
        }

        // GET api/task/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            if (id < 1) return BadRequest("id must be greater than 0.");
            return Ok(await _taskService.FindTaskAsync(id));
        }

        // POST api/task
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTaskRequest model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _taskService.CreateTaskAsync(model);
            return Created($"/api/task/{result.Id}", result);
        }

       
    }
}
