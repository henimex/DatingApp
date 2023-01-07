using MainAPI.Data;
using MainAPI.Dtos;
using MainAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //Validation Operations

            userForRegisterDto.Username = userForRegisterDto.Username.Trim().ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("User Alrready Exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username,
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }
    }
}
