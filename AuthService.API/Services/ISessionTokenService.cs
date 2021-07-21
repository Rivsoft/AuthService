using AuthService.API.Models;
using AuthService.Data.Entities;
using System;
using System.Threading.Tasks;

namespace AuthService.API.Services
{
    public interface ISessionTokenService
    {
        Task<SessionToken> ValidateSessionToken(Guid tokenId);
    }
}