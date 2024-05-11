using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet]
        public IDictionary<string, bool> GetAdminSpecificDetails()
        {
            return new Dictionary<string, bool>
                {
                    { "isAdmin", true }
                };
        }
    }
}
