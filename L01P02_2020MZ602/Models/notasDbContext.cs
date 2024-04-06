using Microsoft.EntityFrameworkCore;


namespace L01P02_2020MZ602.Models
{
    public class notasDbContext : DbContext
    {

        public notasDbContext(DbContextOptions options) : base(options) 
        { 

        } 

        public DbSet<facultades> facultades { get; set; }

        public DbSet<Alumnos> alumnos { get; set; }

        public DbSet<Materias> materias { get; set; }

        public DbSet<Departamentos> departamentos { get; set; }

    }
}
