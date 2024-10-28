namespace GestionAcademica.Models
{
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Codigo { get; set; }

        // Relación con Matricula
        public ICollection<Matricula> Matriculas { get; set; }
    }
}
