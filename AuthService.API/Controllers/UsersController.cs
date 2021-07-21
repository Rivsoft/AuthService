using AuthService.API.Core.Exceptions;
using AuthService.API.Core.Security;
using AuthService.API.Models;
using AuthService.API.Services;
using AuthService.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AuthService.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<SessionsController> _logger;
        private readonly IMapper _mapper;
        private IUserService _userService;
        private ISessionTokenService _sessionTokenService;

        public UsersController(IUserService userService, ISessionTokenService sessionTokenService, 
            ILogger<SessionsController> logger, IMapper mapper)
        {
            _userService = userService;
            _sessionTokenService = sessionTokenService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpDelete("sessions")]
        public async Task<IActionResult> DeleteSessionTokens()
        {
            var user = (User)HttpContext.Items["User"];

            if (user == null)
                throw new ApiApplicationException("Invalid user");

            var response = await _userService.DeleteAllSessionTokens(user.Id);

            return Ok(response);
        }
    }
}
