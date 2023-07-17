using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VeterinariaAPI.Negocio
{
    public class SoloLetrasAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty((string)value))
            {
                return ValidationResult.Success;
            }

            if (!Regex.IsMatch((string)value, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult("Solo se permiten letras");
            }

            return ValidationResult.Success;
        }
    }
}
