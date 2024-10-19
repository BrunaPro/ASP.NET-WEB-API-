using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task_System.Data;
using Task_System.Repository;
using Task_System.Repository.Interface;

namespace Task_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //conf DataBase
            builder.Services.AddDbContext<TasksSystemDBContext>(      //nome da classe dentro de Data folder
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")) //DataBase name
                ); 

            builder.Services.AddScoped<IUserRepository, UserRepository>(); //dependendias do repositorio. Toda vez que chamar a interface IUserRepository a
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();                                                                //classe UserRepository vai ser iniciada

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}