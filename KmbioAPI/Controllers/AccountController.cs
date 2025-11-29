using KmbioAPI.Authentication;
using KmbioAPI.DTOs;
using KmbioAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KmbioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(UserManager<Usuario> userManager, IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = await userManager.FindByNameAsync(model.Email);
                if (existedUser != null)
                {
                    ModelState.AddModelError("", "Email already exists.");
                    return BadRequest("User already exists.");
                }

                var user = new Usuario()
                {
                    UserName = model.Nombre,
                    Email = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var token = GenerateToken(model.Nombre);
                    return Ok(new { token });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return BadRequest(ModelState);
        }

        private string? GenerateToken(string userName)
        {
            var secret = _configuration["JwtConfig:Secret"];
            var issuer = _configuration["JwtConfig:ValidIssuer"];
            var audience = _configuration["JwtConfig:ValidAudience"];
            if (secret is null || issuer is null || audience is null)
            {
                throw new ApplicationException("Jwt is not set in the configuration");
            }
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    if (await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        var token = GenerateToken(model.UserName);
                        return Ok(new { token });
                    }
                }
            }
            return BadRequest(ModelState);
        }
    }
}
