using System.ComponentModel.DataAnnotations;

namespace SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerPolizaPorId
{
    public class ObtenerPolizaPorIdQuery : IQuery
    {
        [Required]
        public int Id { get; set; }
    }
}
