using Microsoft.AspNetCore.Mvc;
using AuthDemo.Application.Dtos.Authentication;
using AuthDemo.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(
            IUserService userService
            )
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserResponse>>> ListAsync()
        {
            return Ok(await _userService.GetUsersAsync());
        }
    }
}
