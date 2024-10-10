using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using static UserApi.Models.Dto;

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
        [HttpPost]
        public ActionResult<User> Post(CreateUserDto craeteUserDto) 
        {
            using (var context = new UserDbContext())
            {
                var user = new User 
                {
                    Id = Guid.NewGuid(),
                    Name = craeteUserDto.Name,
                    Age = craeteUserDto.Age,
                    License = craeteUserDto.License,
                };

                if (user != null)
                {
                    context.NewUsers.Add(user);
                    context.SaveChanges();
                    return StatusCode(201, user);
                }
                return BadRequest();
            }
        }
    }
}
