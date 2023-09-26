using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("Update")]
        public IActionResult Update(UserForUpdateDto user)
        {
            var result = _userService.UserForUpdate(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet("GetByMail")]
        public IActionResult GetByMail(string mail) 
        {
            var result = _userService.GetByMail(mail);
             
            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();

            
        }
    }
}
