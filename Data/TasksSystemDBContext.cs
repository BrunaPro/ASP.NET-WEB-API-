using Microsoft.EntityFrameworkCore;
using Task_System.Models;

namespace Task_System.Data
{
    public class TasksSystemDBContext :DbContext
    {
        TasksSystemDBContext(DbContextOptions<TasksSystemDBContext> options) 
            : base(options) 
        { 
        }  
        
        public DbSet<UserModel> Users { get; set;}
        public DbSet<TaskModel> Tasks { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
            base.OnModelCreating(modelBuilder); 
        
        }

    }
}
