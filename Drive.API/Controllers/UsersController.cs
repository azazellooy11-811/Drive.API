using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Drive.API.Models.Requests;
using Drive.Core.Models;
using Drive.Core.Services;
using Drive.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drive.API.Controllers
{
    [ApiController]
    [Route("driveapi/user/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// ВОЙТИ!!!
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Register(RegistrationRequest users)
        {
            _userService.Register(users);
            return Ok();
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User) HttpContext.Items["User"];
            if (id != currentUser.Id)
                return Unauthorized(new {message = "Unauthorized"});

            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("Profile")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateProfile([FromBody] UserUpdateModel user)
        {
            var currentUser = (User) HttpContext.Items["User"];

            await _userService.Update(currentUser.Id, user);
            return NoContent();
        }
        [HttpGet("AllUser")]
        public List<User> GetAllUser()
        {
            _userService.GetAll();
            return _userService.GetAll();
        }
        
        [HttpGet("Read")]
        [ProducesResponseType(204)]
        public async Task<UserProfile> Read()
        {
            var currentUser = (User) HttpContext.Items["User"];
            var result = await _userService.GetById(currentUser!.Id);
            return UserProfile.FromUser(result);
        }

        [HttpPost("ErrorQuestions")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> AddErrorQuestions(Question question)
        {
            var currentUser = (User)HttpContext.Items["User"];
            await _userService.AddErrorQuestion(currentUser.Id, question.Id);
            return Ok();
        }

    }
}