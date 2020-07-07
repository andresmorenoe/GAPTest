using System;

namespace SegurosTestGAP.Dominio.Polizas
{
    public class Poliza : Entity
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime InicioVigencia { get; set; }

        public short PeriodoCobertura { get; set; }

        public short PorcentajeCobertura { get; set; }

        public decimal Precio { get; set; }

        public TipoRiesgo TipoRiesgo { get; set; }

        public TipoCubrimiento TipoCubrimiento { get; set; }

        public Poliza()
        {
            Nombre = default!;
            Descripcion = default!;
            InicioVigencia = default!;
            TipoRiesgo = default!;
            TipoCubrimiento = default!;
        }

        public Poliza(string nombre, 
            string descripcion, 
            DateTime inicioVigencia,
            short periodoCobertura,
            short porcentajeCobertura,
            decimal precio,
            TipoRiesgo tipoRiesgo,
            TipoCubrimiento tipoCubrimiento)
        {
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
