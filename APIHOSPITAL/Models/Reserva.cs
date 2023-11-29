using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIHOSPITAL.Models
{
    public class Reserva
    {
        [Key]
        public int idReserva { get; set; }
        [StringLength(45)]
        public string Especialidad { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? DiaReserva { get; set; }
        public int Paciente_idPaciente { get; set; }

    }
}
