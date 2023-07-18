using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VeterinariaAPI.Negocio
{
    public class NumeroDocumentoClienteAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty((string)value))
            {
                return ValidationResult.Success;
            }

            if (!Regex.IsMatch((string)value, @"^[0-9A-Z]+$"))
            {
                return new ValidationResult("Solo se permiten números y letras mayúsculas");
            }

            return ValidationResult.Success;
        }
    }
}
