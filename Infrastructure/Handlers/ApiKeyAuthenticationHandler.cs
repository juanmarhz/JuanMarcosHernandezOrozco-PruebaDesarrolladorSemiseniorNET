using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using NumeroAsignadoProject.Application.Interfaces;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace NumeroAsignadoProject.Infrastructure.Handlers
{
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IApiKeyValidator _apiKeyValidator;

        public ApiKeyAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IApiKeyValidator apiKeyValidator)
            : base(options, logger, encoder, clock)
        {
            _apiKeyValidator = apiKeyValidator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("ApiKey", out var apiKeyHeaderValues))
            {
                return AuthenticateResult.Fail("ApiKey header not found");
            }

            var apiKey = apiKeyHeaderValues.FirstOrDefault();

            if (string.IsNullOrEmpty(apiKey))
            {
                return AuthenticateResult.Fail("Invalid ApiKey");
            }

            if (!_apiKeyValidator.ValidateApiKey(apiKey))
            {
                return AuthenticateResult.Fail("Invalid ApiKey");
            }

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, apiKey),
        };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }

}
