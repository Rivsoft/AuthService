using AuthService.API.Models;
using AuthService.Data;
using AuthService.Data.Entities;
using AuthService.Data.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Services
{
    public class UserService : IUserService
    {
        private const int DEFAULT_TOKEN_EXPIRATION_IN_DAYS = 7; //This should most likely be in a configuration file or service.

        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        private IUserRepository _userRepository;
        private ISessionRepository _sessionRepository;

        public UserService(IUserRepository userRepository, ISessionRepository sessionRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _sessionRepository = sessionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateSessionTokenResponse> CreateSessionToken(CreateSessionTokenRequest request)
        {
            // Get the user from the repository
            var user = await _userRepository.GetByUsername(request.Username);

            if (user == null) // Here we would also validate password matches a passwordHash stored in the DB
                throw new ApplicationException("Unable to generate session token");

            // Generate session token
            var token = new SessionToken()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(DEFAULT_TOKEN_EXPIRATION_IN_DAYS)
            };

            // Add token to user entity
            _sessionRepository.AddSessionToken(token);

            // Save token to DB
            await _sessionRepository.SaveAll();

            // Generate Session Token Response including the token Id
            var response = new CreateSessionTokenResponse() { SessionToken = token.Id };

            return response;
        }

        public async Task<User> GetUserById(Guid userId)
        {
            // Get the user from the repository
            var user = await _userRepository.GetByUserId(userId);

            return user;
        }

        public async Task<bool> DeleteAllSessionTokens(Guid userId)
        {
            var user = await _userRepository.GetByUserId(userId);

            if (user == null)
                throw new ApplicationException("User not found");

            foreach (var sessionToken in user.SessionTokens)
            {
                await _sessionRepository.DeleteToken(sessionToken.Id);
            }

            return await _sessionRepository.SaveAll();
        }
    }
}
