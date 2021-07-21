using AuthService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Data.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DataContext _dataContext;

        public SessionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Add a session token entity to the DB context.
        /// </summary>
        /// <param name="sessionToken">The session token to be added</param>
        public void AddSessionToken(SessionToken sessionToken)
        {
            _dataContext.SessionTokens.Add(sessionToken);
        }

        /// <summary>
        /// Returns a Session Token
        /// </summary>
        /// <param name="id">The Id of the session token to be returned</param>
        /// <returns>The session token entity if found, or null otherwise</returns>
        public async Task<SessionToken> GetSessionToken(Guid id)
        {
            var token = await _dataContext.SessionTokens
                .FirstOrDefaultAsync(t => t.Id == id);

            return token;
        }

        /// <summary>
        /// Deletes a Session Token
        /// </summary>
        /// <param name="id">The Guid of the Session Token to be deleted</param>
        /// <returns></returns>
        public async Task DeleteToken(Guid id)
        {
            var token = await GetSessionToken(id);

            if (token != null)
                _dataContext.SessionTokens.Remove(token);
        }

        /// <summary>
        /// Persist all changes to the DB
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAll()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
