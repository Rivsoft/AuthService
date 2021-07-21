using AuthService.Data.Entities;
using System;
using System.Threading.Tasks;

namespace AuthService.Data.Repositories
{
    public interface ISessionRepository
    {
        void AddSessionToken(SessionToken sessionToken);
        Task DeleteToken(Guid id);
        Task<SessionToken> GetSessionToken(Guid id);
        Task<bool> SaveAll();
    }
}