using  Examen_Ribbit.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Examen_Ribbit.Servicios
{
    public interface IProductoServicio
    {
            Task<IEnumerable<Producto>> ObtenerTodos();
            Task<Producto> ObtenerPorId(int id);
            Task Agregar(Producto product);
            Task Actualizar(Producto product);
            Task Eliminar(int id);
        
    }
}
