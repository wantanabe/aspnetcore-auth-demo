using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthDemo.Application.Dtos.Authentication;
using AuthDemo.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemo.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthenticateController(
            IIdentityService identityService
            )
        {
            _identityService = identityService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> LoginAsync([FromBody] LoginRequest request)
        {
            var user = await _identityService.GetUserIdentityAsync(request);

            if (user != null)
            {
                return Ok(new LoginResponse
                {
                    Token = await _identityService.BuildTokenAsync(user)
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var result = await _identityService.CreateUserIdentityAsync(request);

            if (!result.Succeeded)
            {
                var passwordErrors = new List<string>();
                var userNameErrors = new List<string>();
                var emailErrors = new List<string>();

                foreach (var error in result.Errors)
                {
                    if (error.Code.StartsWith("Password"))
                    {
                        passwordErrors.Add(error.Description);
                    }
                    else if (error.Code.Equals("DuplicateUserName"))
                    {
                        userNameErrors.Add(error.Description);
                    }
                    else if (error.Code.Equals("DuplicateEmail"))
                    {
                        emailErrors.Add(error.Description);
                    }
                }

                return BadRequest(new
                {
                    Errors = new
                    {
                        Password = passwordErrors,
                        UserName = userNameErrors,
                        Email = emailErrors
                    }
                });
            }

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("user")]
        public async Task<ActionResult<UserResponse>> ProfileAsync()
        {
            return Ok(await _identityService.GetUserProfileAsync(User.Identity.Name));
        }
    }
}
