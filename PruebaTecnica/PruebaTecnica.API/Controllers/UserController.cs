using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Models;
using PruebaTecnica.BusinessLogic.Interfaces;

namespace PruebaTecnica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
        {

            if (model.FullName == null)
            {
                return BadRequest("Usuario inválido.");
            }
            else if(model.Sex == null)
            {
                return BadRequest("Sexo inválido.");
            }
            
            var user = await _userService.CreateUserAsync(model.FullName, model.Sex, model.DateOfBirth, model.Income);
            
            if (user == null)
                return BadRequest("Falló al crear usuario.");

            return CreatedAtAction(nameof(GetUser), new { userId = user.Id }, user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
