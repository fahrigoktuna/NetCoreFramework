using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreFramework.Presentation.WebAPI.Controllers
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {


        // POST api/values
        [HttpPost]
        [Route("login")]
        public ActionResult<string> Login([FromBody]UserLogin user)
        {

            if (user.Username == "kaan" && user.Password == "kaan")
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Name,"CurrentUserName")
                    }
                    ),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Jwt Key Jwt Key Jwt Key Jwt Key Jwt Key")), SecurityAlgorithms.HmacSha512Signature)
                };


                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(tokenHandler.WriteToken(token));
            }
            return Unauthorized();
        }


    }
}
