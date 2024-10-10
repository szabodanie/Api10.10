using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Migrations
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<User> Get() 
        {
            using (var context = new UserDbContext())
            {
                return Ok(context.NewUsers.ToList());
            }
              
        }
    }
}
