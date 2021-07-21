using AuthService.API.Core.Security;
using AuthService.API.Models;
using AuthService.API.Services;
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
    public class SessionsController : ControllerBase
    {
        private readonly ILogger<SessionsController> _logger;
        private readonly IMapper _mapper;
        private IUserService _userService;
        private ISessionTokenService _sessionTokenService;

        public SessionsController(IUserService userService, ISessionTokenService sessionTokenService, 
            ILogger<SessionsController> logger, IMapper mapper)
        {
            _userService = userService;
            _sessionTokenService = sessionTokenService;
            _logger = logger;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateSessionToken(CreateSessionTokenRequest request)
        {
            var response = await _userService.CreateSessionToken(request);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("{tokenId}/validate")]
        public async Task<IActionResult> ValidateSessionToken(Guid tokenId)
        {
            var token = await _sessionTokenService.ValidateSessionToken(tokenId);

            return Ok(token != null);
        }
    }
}
