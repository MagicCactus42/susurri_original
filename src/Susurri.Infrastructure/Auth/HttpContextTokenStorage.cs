using Microsoft.AspNetCore.Http;
using Susurri.Application.Abstractions;
using Susurri.Core.DTO;
using Microsoft.Extensions.Logging;

namespace Susurri.Infrastructure.Auth
{
    internal sealed class HttpContextTokenStorage : ITokenStorage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HttpContextTokenStorage> _logger;
        private const string TokenKey = "jwt";

        public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor, ILogger<HttpContextTokenStorage> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public void Set(JwtDto jwt)
        {
            if (_httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwt) == true)
            {
                _logger.LogInformation("JWT set successfully.");
            }
            else
            {
                _logger.LogWarning("Failed to set JWT.");
            }
        }

        public JwtDto Get()
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                _logger.LogWarning("HttpContext is null.");
                return null;
            }
            if (_httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
            {
                _logger.LogInformation("JWT retrieved successfully.");
                return jwt as JwtDto;
            }

            _logger.LogWarning("JWT not found in HttpContext.Items.");
            return null;
        }
    }
}