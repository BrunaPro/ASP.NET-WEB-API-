using Microsoft.EntityFrameworkCore;
using Task_System.Data.Map;
using Task_System.Models;

namespace Task_System.Data
{
    public class TasksSystemDBContext :DbContext
    {
        public TasksSystemDBContext(DbContextOptions<TasksSystemDBContext> options) 
            : base(options)
        {    
        }  
        
        public DbSet<UserModel> Users { get; set;}
        public DbSet<TaskModel> Tasks { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder); 
        
        }

    }
}
