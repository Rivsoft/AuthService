using AuthService.Data.Entities;
using System;
using System.Threading.Tasks;

namespace AuthService.Data.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        Task<User> GetByUserId(Guid userId);
        Task<User> GetByUsername(string userName);
        Task<bool> SaveAll();
    }
}