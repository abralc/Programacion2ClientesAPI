namespace Programacion2ClientesAPI.DTOs;

public class ClienteDto
{
    public int Id_cliente { get; set; }
    public string CUI { get; set; } = string.Empty;
    public string NIT { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public DateTime Fecha_Nacimiento { get; set; }
}
