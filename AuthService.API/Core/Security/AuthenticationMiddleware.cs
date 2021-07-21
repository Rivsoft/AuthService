using AuthService.API.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Core.Security
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, ISessionTokenService sessionTokenService)
        {
            var tokenId = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (!string.IsNullOrWhiteSpace(tokenId))
            {
                var token = await sessionTokenService.ValidateSessionToken(Guid.Parse(tokenId));

                if (token != null)
                {
                    // get user and add to context so it can be reused
                    context.Items["User"] = await userService.GetUserById(token.UserId);
                }
            }

            await _next(context);
        }
    }
}
