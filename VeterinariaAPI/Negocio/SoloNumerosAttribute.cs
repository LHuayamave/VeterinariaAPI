using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VeterinariaAPI.Negocio
{
    public class SoloNumerosAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty((string)value))
            {
                return ValidationResult.Success;
            }

            if (!Regex.IsMatch((string)value, @"^[0-9]+$"))
            {
                return new ValidationResult("Solo se permiten números");
            }

            return ValidationResult.Success;
        }
    }
}
