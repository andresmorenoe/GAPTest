using System.ComponentModel.DataAnnotations;

namespace SegurosTestGAP.Aplicacion.Polizas.Comandos.Borrar
{
    public class BorrarPolizaPorIdCommand : ICommand
    {
        [Required]
        public int Id { get; set; }
    }
}
