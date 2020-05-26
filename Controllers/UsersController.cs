using JavaGameAPI.DTO.Authentication;
using JavaGameAPI.DTO.Users;
using JavaGameAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace JavaGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly AppSettings _appSettings;

        public UsersController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUser userParam)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserName == userParam.UserName);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            if (!comparePasswords(user, userParam.Password))
                return BadRequest(new { message = "Username or password is incorrect" });

            var apiUserDTO = new AuthenticateUser()
            {
                ID = user.id,
                UserName = user.UserName,
                Token = generateToken(_appSettings.Secret, user)
            };

            return Ok(apiUserDTO);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUser>>> GetUser()
        {
            var users = await _context.User.ToListAsync();

            return users.Select(u => convertGetUserDto(u)).ToList();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]AuthenticateUser userParam)
        {
            if (userParam == null || userParam.Password == null || userParam.UserName == null)
            {
                return BadRequest(new { message = "Incomplete registration object" });
            }

            string passwordSalt = generateRandomString();

            if(_context.User.FirstOrDefault(u => u.UserName == userParam.UserName) != null)
            {
                return BadRequest("A user with this username already exists");
            }

            User user = new User()
            {
                UserName = userParam.UserName,
                PasswordHash = Encoding.Default.GetString(hash(userParam.Password + passwordSalt)),
                PasswordSalt = passwordSalt
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            var userDTO = new AuthenticateUser()
            {
                ID = user.id,
                UserName = user.UserName,
                Token = generateToken(_appSettings.Secret, user)
            };

            return Ok(userDTO);
        }

        // Authorization test endpoint, shouldn't work if you're not authenticated
        [Authorize]
        [HttpGet("authorizetest")]
        public IActionResult AuthorizeTest()
        {
            return Ok("You're authorized! Your string: " + generateRandomString());
        }

        [NonAction] 
        private bool comparePasswords(User user, string password)
        {
            byte[] hashedPassword = hash(password + user.PasswordSalt);

            string stringHashedPassword = Encoding.Default.GetString(hashedPassword);

            if(stringHashedPassword.Equals(user.PasswordHash))
            {
                return true;
            }

            return false;
        }

        [NonAction]
        private byte[] hash(string input)
        {
            var hashSvc = SHA512.Create();

            return hashSvc.ComputeHash(Encoding.UTF8.GetBytes(input));
        }

        [NonAction]
        private string generateToken(string secret, User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [NonAction]
        private string generateRandomString()
        {
            int length = 7;

            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }

            return str_build.ToString();
        }

        [NonAction]
        private GetUser convertGetUserDto(User user)
        {
            return new GetUser()
            {
                ID = user.id,
                UserName = user.UserName
            };
        }
    }
}
