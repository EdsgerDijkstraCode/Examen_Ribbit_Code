using Examen_Ribbit.Servicios;
using Microsoft.AspNetCore.Mvc;
using Examen_Ribbit.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Swashbuckle.AspNetCore.Annotations;


namespace SolidApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductosController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Devuelve todos los productos", Description = "Devuelve todos los productos con la opcion de filtrar por nombre y rango de precios")]

        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerTodos([FromQuery] string nombre=null, [FromQuery] decimal? PrecioInferior=0 , [FromQuery] decimal? PrecioSuperior=0)
        {

            var products = await _productoServicio.ObtenerTodos();

            if (!string.IsNullOrEmpty(nombre)) 
            { 
                products = products.Where(p => p.Nombre.Contains(nombre)); 
            }

         if (PrecioInferior.HasValue && PrecioInferior >0) 
            { 
                products = products.Where(p => p.Precio >= PrecioInferior.Value);
            }
         

            if (PrecioSuperior.HasValue && PrecioSuperior > 0)
            {
                products = products.Where(p => p.Precio <= PrecioSuperior.Value);
            }



            return Ok(products);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Devuelve producto por ID", Description = "Devuelve producto por filtro ID")]
        public async Task<ActionResult<Producto>> ObtenerPorId(int id)
        {
            var product = await _productoServicio.ObtenerPorId(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Agrega un producto", Description = "Agrega un producto a la base de datos")]
        public async Task<ActionResult> Agregar([FromBody] Producto producto)
        {
            if (producto == null) return BadRequest();

            await _productoServicio.Agregar(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualiza registro de producto", Description = "Actualiza registro de producto por ID")]
        public async Task<ActionResult> Actualizar(int id, [FromBody] Producto producto)
        {
            if (id != producto.Id) return BadRequest();

            await _productoServicio.Actualizar(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Elimina registro de producto", Description = "Elimina registro de producto por ID")]
        public async Task<ActionResult> Eliminar(int id)
        {
            await _productoServicio.Eliminar(id);
            return NoContent();
        }
    }
}