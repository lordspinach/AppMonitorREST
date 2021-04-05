using AppMonitorREST.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AppMonitorREST.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]Login requestBody)
        {
            var user = await _userManager.FindByNameAsync(requestBody.UserName);
            if (user == null)
                return NotFound();

            var result = await _signInManager.CheckPasswordSignInAsync(user, requestBody.Password, false);

            if (result.Succeeded)
            {
                return Ok(new 
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    token = "temp"
                });
            }
            return Unauthorized();
        }
    }
}
