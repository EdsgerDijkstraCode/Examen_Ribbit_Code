using Examen_Ribbit.Repositorios;
using Examen_Ribbit.Modelos;


namespace Examen_Ribbit.Servicios
{
    public class ProductoServicio: IProductoServicio
    {
  
            private readonly IProductoRepositorio _productRepository;

            public ProductoServicio(IProductoRepositorio productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<IEnumerable<Producto>> ObtenerTodos()
            {
                return await _productRepository.ObtenerTodos();
            }

            public async Task<Producto> ObtenerPorId(int id)
            {
                return await _productRepository.ObtenerPorId(id);
            }

            public async Task Agregar(Producto producto)
            {
                await _productRepository.Agregar(producto);
            }

            public async Task Actualizar(Producto producto)
            {
                await _productRepository.Actualizar(producto);
            }

            public async Task Eliminar(int id)
            {
                await _productRepository.Eliminar(id);
            }
            }
}
