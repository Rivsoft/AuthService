using AuthService.API.Models;
using AuthService.Data.Entities;
using System;
using System.Threading.Tasks;

namespace AuthService.API.Services
{
    public interface IUserService
    {
        Task<CreateSessionTokenResponse> CreateSessionToken(CreateSessionTokenRequest request);
        Task<bool> DeleteAllSessionTokens(Guid userId);
        Task<User> GetUserById(Guid userId);
    }
}