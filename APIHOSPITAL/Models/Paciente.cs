using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APIHOSPITAL.Models
{
    public class Paciente
    {
        [Key]
        public int idPaciente { get; set; }
        [StringLength(50)]
        public string NombrePac { get; set; } = string.Empty;
        [StringLength(50)]
        public string ApellidoPac { get; set; } = string.Empty;
        [StringLength(25)]
        public string RunPac { get; set; } = string.Empty;
        [StringLength(50)]
        public string Nacionalidad { get; set; } = string.Empty;
        [StringLength(5)]
        public string Visa { get; set; } = string.Empty;
        [StringLength(10)]
        public string Genero { get; set; } = string.Empty;
        [StringLength(100)]
        public string SintomasPac { get; set; } = string.Empty;
        public int Medico_idMedico { get; set; }
      

    }
}

