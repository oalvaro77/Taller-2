namespace GestionAcademica.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public TimeOnly HoraInicio { get; set; }   
        public TimeOnly HoraFinal {  get; set; }
        public string Dia {  get; set; }

        public int CursoID { get; set; }
        public Curso Curso { get; set; }

        public int ProfesorID { get; set; }
        public Profesor Profesor { get; set; }

        public int AlumnoID { get; set; }

        public Alumno Alumno { get; set; }





    }
}
