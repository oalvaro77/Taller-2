namespace GestionAcademica.Models
{
    public class Facultad
    {

        public string Id { get; set; }  
        public string Nombre { get; set; }


        public ICollection<Profesor> Profesores { get; set; }



    }
}
