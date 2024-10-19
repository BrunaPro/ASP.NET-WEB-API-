using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Task_System.Data;
using Task_System.Models;
using Task_System.Repository.Interface;

namespace Task_System.Repository
{
    public class TaskRepository : ITaskRepository
    { 
        private readonly TasksSystemDBContext dBContext;   
        public TaskRepository(TasksSystemDBContext tasksSystemDBContext)
        {
           dBContext= tasksSystemDBContext;
        }

        public async Task<List<TaskModel>> SearchingAllTasks()
        {
            return await dBContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> SearcingById(int id)
        {
           return  await dBContext.Tasks
               .Include(x => x.User)
               .FirstOrDefaultAsync(x => x.Id == id);
        }
      
        public async Task<TaskModel> Add(TaskModel task)
        {
            await dBContext.Tasks.AddAsync(task);  
            await dBContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel taskById = await SearcingById(id);

            if (taskById == null)
            {
                throw new Exception($"Task by ID: {id} it was not found");
            }

            dBContext.Tasks.Remove(taskById);
            await dBContext.SaveChangesAsync();
            return true;

        }

        public async Task<TaskModel>Update(TaskModel task, int id)
        {
           TaskModel taskById = await SearcingById(id);

            if(taskById == null) 
            {
                throw new Exception($"Task by ID: {id} it was not found");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;  
            taskById.UserId= task.UserId;   

           dBContext.Tasks.Update(taskById);  
            await dBContext.SaveChangesAsync();

            return taskById;
        }
    }
}
