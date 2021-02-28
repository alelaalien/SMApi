using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SM.Core.Entities;
using SM.Core.Interfaces;
using SM.Infraestructure.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Token2Controller : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _security;
        private readonly IPasswordHasher _passwordService;
        private readonly IUserService _userS;

        public Token2Controller(IConfiguration configuration,  IUserService user, ISecurityService security, IPasswordHasher passwordService)
        {
            _configuration = configuration;
            _security = security;
            _passwordService = passwordService;
            _userS = user;
        }


        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //if it is a valid user
            var validation = await IsValidUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(CommonLogin login)
        {
             
            var validation = await UserComprobation(login);
            if (validation.Item1)
            {
                User user = validation.Item2;
                
                //var token = UserToken(user);
             // return Ok(user);
                var token = UserToken(validation.Item2);
                return Ok(new { token, user.Id });
            }

            return NotFound();
        }
        public async Task<IActionResult> CommonAuthentication(CommonLogin u)
        {

            var validation = await UserComprobation(u);
            if (validation.Item1)
            {
                   var token = UserToken(validation.Item2);
                   return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<(bool, Security)> IsValidUser(UserLogin login)
        {
            var user = await _security.GetLoginByCredentials(login);
            var isValid = _passwordService.Check(user.Pass, login.Password);
            return (isValid, user);
        }
        private async Task<(bool, User)> UserComprobation(CommonLogin u)
        {
            var user = await _userS.GetLoginByCredentials(u);
            var isValid = _passwordService.Check(user.Password, u.Password);
            return (isValid, user);
        }


        private string GenerateToken(Security security)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim("User", security.User),
                new Claim(ClaimTypes.Role, security.Role.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddDays(7)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private string UserToken(User u)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
              
                new Claim(ClaimTypes.Email, u.Email),
                new Claim("User", u.Nick),
              
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddDays(7)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
 
