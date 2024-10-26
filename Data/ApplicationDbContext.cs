using GestionAcademica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionAcademica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Horario> Horarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Profesor>()
                .HasOne(p => p.Facultad) // Un profesor tiene una facultad
                .WithMany(f => f.Profesores) // Una facultad tiene muchos profesores
                .HasForeignKey(p => p.FacultadId) // Clave foránea en Profesor
                .OnDelete(DeleteBehavior.Cascade); // Comportamiento al eliminar

            //modelBuilder.Entity<Profesor>()
            //    .HasMany(p => p.Horarios)
            //    .WithOne(h => h.Profesor)
            //    .HasForeignKey(h => h.ProfesorID);




        }

    }
}
