using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Programacion2ClientesAPI.Validations
{
    public class NumeroNoTrivialAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var texto = value.ToString()?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(texto))
            {
                return ValidationResult.Success;
            }

            // Para NIT con guion/K tomamos solamente los números.
            var digitos = new string(
                texto.Where(char.IsDigit).ToArray()
            );

            if (digitos.Length < 2)
            {
                return ValidationResult.Success;
            }

            // Rechaza: 99999999, 1111111111111, etc.
            if (digitos.All(c => c == digitos[0]))
            {
                return new ValidationResult(
                    ErrorMessage ??
                    "El valor no puede contener únicamente dígitos repetidos."
                );
            }

            // Rechaza secuencias como:
            // 12345678
            // 1234567890
            // 2345678901
            if (EsSecuenciaAscendente(digitos))
            {
                return new ValidationResult(
                    ErrorMessage ??
                    "El valor no puede ser una secuencia numérica consecutiva."
                );
            }

            // Rechaza secuencias como:
            // 87654321
            // 9876543210
            if (EsSecuenciaDescendente(digitos))
            {
                return new ValidationResult(
                    ErrorMessage ??
                    "El valor no puede ser una secuencia numérica consecutiva."
                );
            }

            return ValidationResult.Success;
        }

        private static bool EsSecuenciaAscendente(string valor)
        {
            for (int i = 1; i < valor.Length; i++)
            {
                var anterior = valor[i - 1] - '0';
                var actual = valor[i] - '0';

                var esperado = (anterior + 1) % 10;

                if (actual != esperado)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool EsSecuenciaDescendente(string valor)
        {
            for (int i = 1; i < valor.Length; i++)
            {
                var anterior = valor[i - 1] - '0';
                var actual = valor[i] - '0';

                var esperado =
                    anterior == 0
                        ? 9
                        : anterior - 1;

                if (actual != esperado)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
