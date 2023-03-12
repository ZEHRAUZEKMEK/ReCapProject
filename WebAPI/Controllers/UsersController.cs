using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbymail")]
        public IActionResult GetByEmailWithResult(string email)
        {
            var result = _userService.GetByEmailWithResult(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            var result = _userService.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]

        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok("");
        }

        
        [HttpDelete("delete")]

        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updateusernames")]
        public IActionResult UpdateUserNames(User user)
        {
            var result = _userService.UpdateUserNames(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("update")]

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
