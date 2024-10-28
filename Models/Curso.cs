namespace GestionAcademica.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }

        // Relación con Matricula
        public ICollection<Matricula> Matriculas { get; set; }
    }
}
