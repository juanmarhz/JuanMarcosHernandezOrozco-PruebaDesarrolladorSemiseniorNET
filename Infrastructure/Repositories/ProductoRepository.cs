using Microsoft.Data.SqlClient;
using NumeroAsignadoProject.Application.Interfaces;
using NumeroAsignadoProject.Domain.Entities;

namespace NumeroAsignadoProject.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionDB");
        }

        public void CrearProducto(Producto producto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Productos (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
