using System.ComponentModel.DataAnnotations;

namespace GestionAcademica.Models
    {
    public class Profesor
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }

        //Foreign key
        [Required]
        public int FacultadId { get; set; }
        public Facultad Facultad { get; set; }

        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        
            


        }
    }
