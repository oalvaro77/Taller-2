namespace GestionAcademica.Models
{
    public class Matricula
    {
        public int MatriculaId { get; set; }
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaMatricula { get; set; }

        // Navegación
        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }
    }
}
