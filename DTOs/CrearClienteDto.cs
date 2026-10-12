using System.ComponentModel.DataAnnotations;
using Programacion2ClientesAPI.Validations;

namespace Programacion2ClientesAPI.DTOs
{
    public class CrearClienteDto
    {
        [Required(
            ErrorMessage = "El CUI es obligatorio."
        )]
        [RegularExpression(
            @"^\d{13}$",
            ErrorMessage =
                "El CUI debe contener exactamente 13 dígitos."
        )]
        [NumeroNoTrivial(
            ErrorMessage =
                "El CUI no puede contener todos los dígitos iguales ni ser una secuencia consecutiva."
        )]
        public string CUI { get; set; } = string.Empty;


        [Required(
            ErrorMessage = "El NIT es obligatorio."
        )]
        [RegularExpression(
            @"^(?:\d{8,9}|\d{6,9}-[0-9Kk])$",
            ErrorMessage =
                "El NIT debe tener 8 o 9 dígitos, o utilizar el formato numérico con guion y dígito verificador, por ejemplo 1234567-8 o 1234567-K."
        )]
        [NumeroNoTrivial(
            ErrorMessage =
                "El NIT no puede contener todos los dígitos iguales ni ser una secuencia consecutiva."
        )]
        public string NIT { get; set; } = string.Empty;


        [Required(
            ErrorMessage = "Los nombres son obligatorios."
        )]
        [StringLength(
            100,
            ErrorMessage =
                "Los nombres no pueden superar 100 caracteres."
        )]
        public string Nombres { get; set; } = string.Empty;


        [Required(
            ErrorMessage = "Los apellidos son obligatorios."
        )]
        [StringLength(
            100,
            ErrorMessage =
                "Los apellidos no pueden superar 100 caracteres."
        )]
        public string Apellidos { get; set; } = string.Empty;


        [StringLength(
            250,
            ErrorMessage =
                "La dirección no puede superar 250 caracteres."
        )]
        public string? Direccion { get; set; }


        [RegularExpression(
            @"^\d{8}$",
            ErrorMessage =
                "El teléfono debe contener exactamente 8 dígitos."
        )]
        [NumeroNoTrivial(
            ErrorMessage =
                "El teléfono no puede contener todos los dígitos iguales ni ser una secuencia consecutiva."
        )]
        public string? Telefono { get; set; }


        [Required(
            ErrorMessage =
                "La fecha de nacimiento es obligatoria."
        )]
        public DateTime Fecha_Nacimiento { get; set; }
    }
}