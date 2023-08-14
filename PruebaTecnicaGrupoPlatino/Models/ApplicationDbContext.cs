using Microsoft.EntityFrameworkCore;
namespace PruebaTecnicaGrupoPlatino.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Alumno> alumno { get; set; }
        public DbSet<Alumno_Detalle> alumno_detalle { get; set; } 
        public DbSet<Aula> aula { get; set; }
        public DbSet<Clase> clase { get; set; }
        public DbSet<Clase_Detalle> clase_detalle { get; set; }
        public DbSet<Maestro> maestro { get; set; }
        public DbSet<Maestro_Detalle> maestro_detalle { get; set; }

    }
}
