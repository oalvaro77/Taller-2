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


    }
}
