using AuthService.API.Models;
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
    public class SessionTokenService : ISessionTokenService
    {
        private readonly ILogger<SessionTokenService> _logger;
        private readonly IMapper _mapper;

        private ISessionRepository _sessionRepository;

        public SessionTokenService(ISessionRepository sessionRepository, IMapper mapper, ILogger<SessionTokenService> logger)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SessionToken> ValidateSessionToken(Guid tokenId)
        {
            var sessionToken = await _sessionRepository.GetSessionToken(tokenId);

            var isValidToken = (sessionToken != null && sessionToken.ExpiresAt > DateTime.UtcNow);

            return isValidToken ? sessionToken : null;
        }
    }
}
