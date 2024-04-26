using NumeroAsignadoProject.Application.Interfaces;

namespace NumeroAsignadoProject.Application.Services
{
    public class ApiKeyValidator : IApiKeyValidator
    {
        private readonly IApiKeyValidatorRepository _apiKeyValidatorRepository;

        public ApiKeyValidator(IApiKeyValidatorRepository apiKeyValidatorRepository)
        {
            _apiKeyValidatorRepository = apiKeyValidatorRepository;
        }

        public bool ValidateApiKey(string apiKey)
        {
            return _apiKeyValidatorRepository.getApiKey(apiKey);
        }

        public int GetClienteId(string apiKey)
        {
            return _apiKeyValidatorRepository.getClienteId(apiKey);
        }

    }
}
