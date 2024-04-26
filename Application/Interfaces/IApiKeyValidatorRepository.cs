namespace NumeroAsignadoProject.Application.Interfaces
{
    public interface IApiKeyValidatorRepository
    {
        bool getApiKey(string apiKey);
        int getClienteId(string apiKey);
    }
}
