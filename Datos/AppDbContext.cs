using Examen_Ribbit.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Examen_Ribbit.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
    }

    public static class DataSeeder
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Productos.Any())
            {
                context.Productos.AddRange(
                    new Producto { Nombre = "Producto Prueba1", Precio = 10,Cantidad=1,FechaCreacion=DateTime.Today },
                    new Producto { Nombre = "Producto Prueba2", Precio = 20, Cantidad = 1, FechaCreacion = DateTime.Today },
                                        new Producto { Nombre = "Producto Prueba3", Precio = 30, Cantidad = 1, FechaCreacion = DateTime.Today }
                );
                context.SaveChanges();
            }
        }
    }
}
