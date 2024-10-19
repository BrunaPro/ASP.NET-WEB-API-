using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_System.Models;
using Task_System.Repository.Interface;

namespace Task_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userrepository;


        public UserController(IUserRepository userrepository)
        {
            _userrepository = userrepository;

        }



        //searching all the user 
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchingAllUsers()
        {
            List<UserModel> users = await _userrepository.SearchingAllUsers();
            return Ok(users);
        }

        //searching only one user by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SearchingById(int id)
        {
            UserModel user = await _userrepository.SearcingById(id);
            return Ok(user);
        }

        //Register user  
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userrepository.Add(userModel);
            return Ok(user);
        }

        //Update user  
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.Id= id; 
            UserModel user = await _userrepository.Update(userModel, id);
            return Ok(user);
        }

        //Delete user  
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete (int id)
        {
            
            bool delete = await _userrepository.Delete(id);
            return Ok(delete);
        }








    }
}

