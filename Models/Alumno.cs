namespace GestionAcademica.Models
{
    public class Alumno
    {

            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Correo { get; set; }
            public DateOnly FechaNacimiento {  get; set; }

    }
}
