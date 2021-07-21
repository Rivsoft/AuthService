using System;

namespace AuthService.API.Models
{
    public class CreateSessionTokenResponse
    {
        public Guid SessionToken { get; set; }
    }
}