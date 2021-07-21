using AuthService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Add a user entity to the DB context.
        /// </summary>
        /// <param name="user">The User to be added</param>
        public void AddUser(User user)
        {
            _dataContext.Users.Add(user);
        }

        /// <summary>
        /// Returns an User
        /// </summary>
        /// <param name="userName">The user name of the User to be returned</param>
        /// <returns>The User entity if found, or null otherwise</returns>
        public async Task<User> GetByUsername(string userName)
        {
            var user = await _dataContext.Users
                .Include(u => u.SessionTokens)
                .Where(t => t.UserName.ToLower() == userName.ToLower())
                .FirstOrDefaultAsync();

            return user;
        }

        /// <summary>
        /// Returns an User
        /// </summary>
        /// <param name="userId">The user id of the User to be returned</param>
        /// <returns>The User entity if found, or null otherwise</returns>
        public async Task<User> GetByUserId(Guid userId)
        {
            var user = await _dataContext.Users
                .Include(u => u.SessionTokens)
                .FirstOrDefaultAsync(t => t.Id == userId);

            return user;
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
