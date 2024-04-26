using NumeroAsignadoProject.Application.Interfaces;

namespace NumeroAsignadoProject.Application.Services
{
    public class NumeroAsignadoService : INumeroAsignadoService
    {
        private readonly INumeroAsignadoRepository _numeroAsignadoRepository;

        public NumeroAsignadoService(INumeroAsignadoRepository numeroAsignadoRepository)
        {
            _numeroAsignadoRepository = numeroAsignadoRepository;
        }

        public int AsignarNumero(int clienteId)
        {
            return _numeroAsignadoRepository.AsignarNumero(clienteId);
        }
    }
}
