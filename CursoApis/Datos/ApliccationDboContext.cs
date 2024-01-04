using CursoApis.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CursoApis.Datos
{
    public class ApliccationDboContext:DbContext
    {
        public ApliccationDboContext(DbContextOptions<ApliccationDboContext> options):base(options)
        {
           
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
               new Villa()
               {
                   Id = 1,
                   Nombre = "Villa Real",
                   Detalle = "Detalle de la Villa...",
                   imageUrl = "",
                   Ocupantes = 5,
                   MetrosCuadrados = 50,
                   Tarifa = 200,
                   Amenidad = "",
                   FechaActualizacion = DateTime.Now,
                   FechaCreacion = DateTime.Now
               },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Villa Falsa",
                    Detalle = "Detalle de la Villa...",
                    imageUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaActualizacion = DateTime.Now,
                    FechaCreacion = DateTime.Now
                }
               );

               
        }

    }
}
