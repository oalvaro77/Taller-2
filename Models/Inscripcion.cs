namespace GestionAcademica.Models
{
    public class Inscripcion
    {
        public int Id { get; set; }
        public DateOnly FechaInscripcion { get; set; }

        //Foreign key
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }



    }
}
