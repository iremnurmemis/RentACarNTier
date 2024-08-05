using Business;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService;
        public UsersController(IUserService userrService)
        {
            _userService = userrService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users=_userService.GetAll();
            if(users.Success)
                return Ok(users);
            return BadRequest(users);
        }
        
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int userId)
        {
            var users=_userService.GetByUserId(userId);
            if(users.Success)
                return Ok(users);
            return BadRequest(users);
        }

        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("Update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
