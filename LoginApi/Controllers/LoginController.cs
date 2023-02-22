using CarDealershipApi.Database;
using LoginApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LoginApi.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase {
        private UserRepository _userRepository = new UserRepository();

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public IActionResult Login(LoginRequest request) {
            if (_userRepository.CheckUser(request)) {
                return Ok(_userRepository.GetUserDetails(request.Username));
            }
            return StatusCode(404, "User Not Found");
        }

        
    }
}
