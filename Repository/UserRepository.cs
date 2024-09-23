using Microsoft.EntityFrameworkCore;
using Task_System.Data;
using Task_System.Models;
using Task_System.Repository.Interface;

namespace Task_System.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TasksSystemDBContext dBContext;   
        public UserRepository(TasksSystemDBContext tasksSystemDBContext)
        {
           dBContext= tasksSystemDBContext;
        } 
        public async Task<List<UserModel>> SearchingAllUsers()
        {
            return await dBContext.Users.ToListAsync();
        }

        public async Task<UserModel> SearcingById(int id)
        {
           return  await dBContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }
           public async Task<UserModel> Add(UserModel user)
        {
            await dBContext.Users.AddAsync(user);  
            await dBContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userbyId = await SearcingById(id);

            if (userbyId == null)
            {
                throw new Exception($"User by ID: {id} it was not found");
            }

            dBContext.Users.Remove(userbyId);
            await dBContext.SaveChangesAsync();
            return true;

        }

        async Task<UserModel> IUserRepository.Upload(UserModel user, int id)
        {
           UserModel userbyId = await SearcingById(id);

            if(userbyId == null) 
            {
                throw new Exception($"User by ID: {id} it was not found");
            }

            userbyId.Name = user.Name;
            userbyId.Email = user.Email;

           dBContext.Users.Update(userbyId);  
            await dBContext.SaveChangesAsync();

            return userbyId;
        }
    }
}
