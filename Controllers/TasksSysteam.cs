using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_System.Models;

namespace Task_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //searching the user 
        [HttpGet]
        public ActionResult<List<UserModel>> SearchingAllUsers()
        {
            return Ok();
        } 
    }
}
