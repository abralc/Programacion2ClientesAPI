using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programacion2ClientesAPI.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_cliente { get; set; }

        [Required]
        [StringLength(13)]
        public string CUI { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string NIT { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Direccion { get; set; }

        [StringLength(20)]
        public string? Telefono { get; set; }

        [Required]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}