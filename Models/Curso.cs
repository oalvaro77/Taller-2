namespace GestionAcademica.Models
{
    public class Curso
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Creditos { get; set; }

        public ICollection<Horario> Horarios { get; set; }


    }
}
