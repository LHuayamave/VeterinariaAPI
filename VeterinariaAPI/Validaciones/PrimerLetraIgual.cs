using System;
using System.ComponentModel.DataAnnotations;

namespace VeterinariaAPI.Validaciones
{
    public class PrimeraLetraIgualAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var idTipoPacienteValue = validationContext.ObjectType.GetProperty("idTipoPaciente").GetValue(validationContext.ObjectInstance, null) as string;
            var tipoPacienteValue = validationContext.ObjectType.GetProperty("tipoPaciente").GetValue(validationContext.ObjectInstance, null) as string;

            if (!string.IsNullOrEmpty(idTipoPacienteValue) && !string.IsNullOrEmpty(tipoPacienteValue))
            {
                var primeraLetraIdTipoPaciente = idTipoPacienteValue[0];
                var primeraLetraTipoPaciente = tipoPacienteValue[0];

                if (primeraLetraIdTipoPaciente != primeraLetraTipoPaciente)
                {
                    return new ValidationResult("La primera letra de idTipoPaciente debe ser igual a la primera letra de tipoPaciente.");
                }
            }

            return ValidationResult.Success;
        }
    }
}