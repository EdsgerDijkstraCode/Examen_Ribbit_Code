
using Microsoft.EntityFrameworkCore;
using Examen_Ribbit.Datos;
using Examen_Ribbit.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Examen_Ribbit.Repositorios
{
    public class ProductoRepositorio:IProductoRepositorio
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProductoRepositorio(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Producto>> ObtenerTodos()
        {
            return await _context.Productos.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Producto> ObtenerPorId(int id)
        {
            return await _context.Productos.FindAsync(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task Agregar(Producto product)
        {
            await _context.Productos.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task Actualizar(Producto product)
        {
            _context.Productos.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Eliminar(int id)
        {
            var product = await ObtenerPorId(id);
            if (product != null)
            {
                _context.Productos.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
