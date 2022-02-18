using API.Dtos;
using API.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using surstroem.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        //private readonly IUserService _userService;

        public AuthenticationController(IConfiguration configuration /*IUserService userService*/)
        {
            _configuration = configuration;
            //_userService = userService;
        }

        /*        [HttpGet, Authorize]
                public ActionResult<string> GetMe()
                {
                    var userName = _userService.GetMyName();
                    return Ok(userName);

                    //var userName = User?.Identity?.Name;
                    //var userName2 = User.FindFirstValue(ClaimTypes.Name);
                    //var role = User.FindFirstValue(ClaimTypes.Role);
                    //return Ok(new { userName, userName2, role });
                }*/

        [HttpPost("register")]
        public ActionResult<User> Register(LoginDto request)
        {
            CreatePasswordHash(request.Password, out string passwordHash, out string passwordSalt);

            user.Firstname = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(LoginDto request)
        {
            if (user.Firstname != request.Username)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Firstname),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                var salt = hmac.Key;
                var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                passwordHash = System.Text.Encoding.UTF8.GetString(hash, 0, hash.Length);
                passwordSalt = System.Text.Encoding.UTF8.GetString(salt, 0, salt.Length);
            }
        }

        private bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            var salt = System.Text.Encoding.UTF8.GetBytes(passwordSalt);
            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var hash = System.Text.Encoding.UTF8.GetBytes(passwordHash);
                return computedHash.SequenceEqual(hash);
            }
        }
    }
}