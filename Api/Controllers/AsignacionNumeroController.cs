using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NumeroAsignadoProject.Application.Interfaces;
using NumeroAsignadoProject.Domain.DTOs;

namespace NumeroAsignadoProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = "ApiKeyAuthentication")]
    public class AsignacionNumeroController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly INumeroAsignadoService _numeroAsignadoService;
        private readonly IApiKeyValidator _apiKeyValidator;

        public AsignacionNumeroController(IProductoService productoService, INumeroAsignadoService numeroAsignadoService, IApiKeyValidator apiKeyValidator)
        {
            _productoService = productoService;
            _numeroAsignadoService = numeroAsignadoService;
            _apiKeyValidator = apiKeyValidator;
        }

        /// <summary>
        /// Endpoint para la creación de productos o servicios
        /// </summary>
        /// <param name="productoDto"></param>
        /// <returns></returns>
        [HttpPost("CrearProducto")]
        public IActionResult CrearProducto([FromBody] ProductoDTO productoDto)
        {
            _productoService.AgregarProducto(productoDto);
            return Ok("Producto creado con exito");
        }

        /// <summary>
        /// Endpoint para la asignación de numero por cliente
        /// </summary>
        /// <returns></returns>
        [HttpPost("AsignarNumero")]
        public IActionResult AsignarNumero()
        {
            string apiKey = HttpContext.Request.Headers["ApiKey"];
            int clienteId = _apiKeyValidator.GetClienteId(apiKey);
            int numeroAsignado = _numeroAsignadoService.AsignarNumero(clienteId);
            return Ok(numeroAsignado);
        }
    }
}
