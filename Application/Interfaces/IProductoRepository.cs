using NumeroAsignadoProject.Domain.Entities;

namespace NumeroAsignadoProject.Application.Interfaces
{
    public interface IProductoRepository
    {
        void CrearProducto(Producto producto);
    }
}
