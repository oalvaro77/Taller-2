namespace GestionAcademica.Models
{
    public class Facultad
    {

        public int Id { get; set; }
        public string Nombre { get; set; }


        public ICollection<Profesor> Profesores { get; set; } = new List<Profesor>();


    }


}



