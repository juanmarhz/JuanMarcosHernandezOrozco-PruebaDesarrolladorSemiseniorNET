using NumeroAsignadoProject.Application.Interfaces;

namespace NumeroAsignadoProject.Infrastructure.Repositories
{
    public class ApiKeyValidatorRepository : IApiKeyValidatorRepository
    {
        private readonly EntityFrameworkContext _context;

        public ApiKeyValidatorRepository(EntityFrameworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permite consultar si el apiKey ingresado existe para un cliente
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public bool getApiKey(string apiKey)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.ApiKey == apiKey);
            return cliente != null;
        }

        /// <summary>
        /// Metodo que permite identificar  el numero de identificación del cliente en relación con el ApiKey
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public int getClienteId(string apiKey)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.ApiKey == apiKey);
            return cliente.Id;
        }
    }
}
