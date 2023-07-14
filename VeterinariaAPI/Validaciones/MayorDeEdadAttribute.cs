using System;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Validaciones
{
    public class MayorDeEdadAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value == null || !(value is DateTime))
                {
                    return ValidationResult.Success;
                }

                DateTime fechaNacimiento = (DateTime)value;
                DateTime fechaActual = DateTime.Today;

                int edad = fechaActual.Year - fechaNacimiento.Year;

                if (fechaNacimiento > fechaActual.AddYears(-edad))
                {
                    edad--;
                }

                if (edad < 18)
                {
                    return new ValidationResult("Debe ser mayor de 18 años");
                }

                return ValidationResult.Success;
            }
            catch (Exception ex)
            {
                return new ValidationResult($"Error de validación: {ex.Message}");
            }
        }
    }
}

