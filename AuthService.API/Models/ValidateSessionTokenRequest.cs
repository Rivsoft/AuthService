using System;

namespace AuthService.API.Models
{
    public class ValidateSessionTokenRequest
    {
        public Guid SessionTokenId { get; internal set; }
    }
}