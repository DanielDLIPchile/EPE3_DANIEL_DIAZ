using System.ComponentModel.DataAnnotations;

namespace APIHOSPITAL.Models
{
    public class Medico
    {
        [Key]
        public int idMedico { get; set; }
        [StringLength(50)]
        public string NombreMed { get; set; } = string.Empty;
        [StringLength(50)]
        public string ApellidoMed { get; set; } = string.Empty;
        [StringLength(50)]
        public string RunMed { get; set; } = string.Empty;
        [StringLength(5)]
        public string Eunacom { get; set; } = string.Empty;
        [StringLength(45)]
        public string NacionalidadMed { get; set; } = string.Empty;
        [StringLength(45)]
        public string Especialidad { get; set; } = string.Empty;
        public TimeSpan? Horarios { get; set; } = TimeSpan.Zero;
        public int? TarifaHr { get; set; }
    }
}
