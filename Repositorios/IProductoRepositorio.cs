using Examen_Ribbit.Modelos;


namespace Examen_Ribbit.Repositorios   
{
    public interface IProductoRepositorio
    {
        Task<IEnumerable<Producto>> ObtenerTodos();
        Task<Producto> ObtenerPorId(int id);
        Task Agregar(Producto Producto);
        Task Actualizar(Producto product);
        Task Eliminar(int id);
    }
}
