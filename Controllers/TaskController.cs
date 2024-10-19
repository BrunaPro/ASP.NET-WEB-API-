using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_System.Models;
using Task_System.Repository.Interface;

namespace Task_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskrepository;


        public TaskController(ITaskRepository taskrepository)
        {
            _taskrepository = taskrepository;

        }

       
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> SearchingAllTasks()
        {
            List<TaskModel> task = await _taskrepository.SearchingAllTasks();
            return Ok(task);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> SearchingById(int id)
        {
            TaskModel task = await _taskrepository.SearcingById(id);
            return Ok(task);
        }

        
        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskrepository.Add(taskModel);
            return Ok(task);
        }

         
        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> Update([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id= id; 
            TaskModel task = await _taskrepository.Update(taskModel, id);
            return Ok(task);
        }

 
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> Delete (int id)
        {
            
            bool delete = await _taskrepository.Delete(id);
            return Ok(delete);
        }
    }
}

