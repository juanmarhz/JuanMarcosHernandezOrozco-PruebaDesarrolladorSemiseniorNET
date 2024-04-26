using Microsoft.EntityFrameworkCore;
using NumeroAsignadoProject.Application.Interfaces;
using NumeroAsignadoProject.Domain.Entities;

namespace NumeroAsignadoProject.Infrastructure.Repositories
{
    public class NumeroAsignadoRepository : INumeroAsignadoRepository
    {
        private readonly EntityFrameworkContext _context;

        public NumeroAsignadoRepository(EntityFrameworkContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permite realizar llamado a SP para la asignación de un número haciendo uso de Entity Framework
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        public int AsignarNumero(int clienteId)
        {
            var resultados = _context.Set<NumeroAsignado>()
                .FromSqlInterpolated($"EXEC AsignarNumero {clienteId}")
                .AsEnumerable()
                .SingleOrDefault();

            return resultados.Numero;
        }
    }
}
