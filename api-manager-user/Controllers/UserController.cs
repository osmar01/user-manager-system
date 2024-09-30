using api_manager_user.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api_manager_user.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> ListAll()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> FindById(int id)
        {
            User user = await _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Insert([FromBody] User user)
        {
            bool existsEmail = (bool) await _userRepository.VerifyEmailExistent(user.email);

            if (existsEmail)
            {
                return BadRequest(new { message = "O e-mail já está cadastrado." });
            }
            else
            {

                var passwordHash = HashPassword(user.senha);
                user.senha = passwordHash;

                User userModel = await _userRepository.Create(user);
                return Ok(userModel);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> Update([FromBody] User user, int id)
        {
            var passwordHash = HashPassword(user.senha);
            user.senha = passwordHash;

            User userModel = await _userRepository.Update(id,user);
            return Ok(userModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            User userModel = await _userRepository.Delete(id);
            return Ok(userModel);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
