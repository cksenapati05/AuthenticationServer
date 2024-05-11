using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IDictionary<string, bool> GetuserSpecificDetails()
        {
            return new Dictionary<string, bool>
                {
                    { "isUser", true }
                };
        }
    }
}
