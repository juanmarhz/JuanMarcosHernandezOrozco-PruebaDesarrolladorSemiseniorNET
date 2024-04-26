using NumeroAsignadoProject.Application.Interfaces;
using NumeroAsignadoProject.Domain.DTOs;
using NumeroAsignadoProject.Domain.Entities;

namespace NumeroAsignadoProject.Application.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public void AgregarProducto(ProductoDTO productoDto)
        {
            //Mapeo de DTO a Entidad
            var producto = new Producto
            {
                Nombre = productoDto.Nombre,
                Descripcion = productoDto.Descripcion
            };

            _productoRepository.CrearProducto(producto);
        }
    }
}
