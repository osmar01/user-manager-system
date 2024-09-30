using api_manager_user.Dto;
using api_manager_user.Infra;
using api_manager_user.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace api_manager_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        IUserRepository _userRepository;

        public loginController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> login([FromBody] UserDTO userDto)
        {
            // usuario padrao admin -- -- -- -- --
            if (userDto.email == "admin@jabil.com" && userDto.senha == "admin2024")
            {
                var token = generateToken(userDto);
                return Ok(new {token});
            }

            User user = await _userRepository.GetUserByEmail(userDto.email);

            if (user == null)
            {
                return Unauthorized(new { message = "E-mail ou senha inválidos." });
            }

            if (VerifyPassword(userDto.senha, user.senha))
            {
                UserDTO userToken = new UserDTO();
                userToken.email = user.email;
                userToken.senha = user.senha;

                var token = generateToken(userToken);
                return Ok(new { token });
            }

            return BadRequest();
        }


        private string generateToken(UserDTO user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ds34f-ygt56-jvcfdkoiytraqwxxodmf$f3@ghcda"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Jabil",
                audience: "manager-user",
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
