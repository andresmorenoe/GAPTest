using System;

namespace SegurosTestGAP.Aplicacion.Polizas
{
    public class PolizaViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime InicioVigencia { get; set; }

        public short PeriodoCobertura { get; set; }

        public short PorcentajeCobertura { get; set; }

        public decimal Precio { get; set; }

        public string TipoRiesgo { get; set; }

        public string TipoCubrimiento { get; set; }

        public PolizaViewModel()
        {
            Nombre = default!;
            Descripcion = default!;
            InicioVigencia = default!;
            TipoRiesgo = default!;
            TipoCubrimiento = default!;
        }

        public PolizaViewModel(int id, string nombre,
            string descripcion,
            DateTime inicioVigencia,
            short periodoCobertura,
            short porcentajeCobertura,
            decimal precio,
            string tipoRiesgo,
            string tipoCubrimiento)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            InicioVigencia = inicioVigencia;
            PeriodoCobertura = periodoCobertura;
            PorcentajeCobertura = porcentajeCobertura;
            Precio = precio;
            TipoRiesgo = tipoRiesgo;
            TipoCubrimiento = tipoCubrimiento;
        }
    }
}
