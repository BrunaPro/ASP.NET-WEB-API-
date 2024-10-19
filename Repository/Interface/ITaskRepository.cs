using Microsoft.AspNetCore.Razor.TagHelpers;
using Task_System.Models;

namespace Task_System.Repository.Interface
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> SearchingAllTasks();
        
        Task<TaskModel> SearcingById(int id);
        Task<TaskModel> Add(TaskModel tasl);
        Task<TaskModel> Update(TaskModel task, int id);

        Task<bool> Delete(int id);


    }
}
