using Task_System.Models;

namespace Task_System.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> SearchingAllUsers();
        
        Task<UserModel> SearcingById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);

        Task<bool> Delete(int id);


    }
}
