using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationServer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost(Name ="GetJwtToken")]
        public IDictionary<string, string> GetJwtToken([FromBody] RequestPayload payload)
        {
            if (payload.Id == "cksenapati05@gmail.com" && payload.Password == "validPassword")
            {
                var token = GenerateJwtToken();
                return new Dictionary<string, string>
                {
                    { "token", token }
                };
            }
            else
                throw new UnauthorizedAccessException();
        }

        [HttpGet]
        public string GetIssuerName()
        {
            return "cksenapati";
        }

        private string GenerateJwtToken()
        {
            var algorithm = SecurityAlgorithms.HmacSha256;

            var claimsCollection = new List<Claim> {
                new Claim("Name", "Chandan"),
                new Claim("id", "1001")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("ThisIsMySecurityKeyThatisOf256bits"));

            var signingCredential = new SigningCredentials(securityKey, algorithm);

            var token = new JwtSecurityToken(
                    issuer: "cksenapati",
                    audience: "cksenapati",
                    claimsCollection,
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: signingCredential
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class RequestPayload
    {
        public string? Id { get; set; }
        public string? Password { get; set; }
    }
}
