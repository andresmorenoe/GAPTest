using System;
using System.ComponentModel.DataAnnotations;

namespace SegurosTestGAP.Aplicacion.Polizas.Comandos.Crear
{
    public class CrearPolizaCommand : ICommand
    {
        [Required]
        [StringLength(50)]
        public string TipoRiesgo { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoCubrimiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(70)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime InicioVigencia { get; set; }

        [Required]
        public short PeriodoCobertura { get; set; }

        [Required]
        [Range(1, 100)]
        [ValidarPorcentajeCoberturaControTipoRiesgoValueAttribute(nameof(TipoRiesgo), ErrorMessage = "El porcetaje de cobertura debe ser menor a 50% cuando la linea de riesgo es de tipo 'Alto'")]
        public short PorcentajeCobertura { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public CrearPolizaCommand()
        {
            TipoRiesgo = default!;
            TipoCubrimiento = default!;
            Nombre = default!;
            Descripcion = default!;
            InicioVigencia = default!;
        }
    }
}
