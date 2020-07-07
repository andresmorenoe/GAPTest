using System;
using System.ComponentModel.DataAnnotations;

namespace SegurosTestGAP.Aplicacion.Polizas.Comandos
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ValidarPorcentajeCoberturaControTipoRiesgoValueAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        public ValidarPorcentajeCoberturaControTipoRiesgoValueAttribute(string comparisonProperty) => _comparisonProperty = comparisonProperty;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            const string PropertyValidationValue = "Alto";
            const int ValueValidationValue = 49; 
            ErrorMessage = ErrorMessageString;

            int currentValue = int.Parse(value.ToString());

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException($"Property {_comparisonProperty} not found");
            }

            var comparisonValue = (string)property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue.Equals(PropertyValidationValue) && currentValue > ValueValidationValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

    }
}
