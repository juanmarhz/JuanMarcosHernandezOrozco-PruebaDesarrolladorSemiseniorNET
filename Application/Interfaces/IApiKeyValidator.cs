namespace NumeroAsignadoProject.Application.Interfaces
{
    public interface IApiKeyValidator
    {
        bool ValidateApiKey(string apiKey);
        int GetClienteId(string apiKey);
    }
}
