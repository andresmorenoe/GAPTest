using System.ComponentModel.DataAnnotations;

namespace SegurosTestGAP.Aplicacion.Clientes.Comandos.Crear
{
    public class CrearClienteCommand : ICommand
    {
        [Required]
        [StringLength(50)]
        public string TipoDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(10)]
        public string Documento { get; set; }

        [StringLength(100)]
        [RegularExpression(@"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}")]
        public string? Email { get; set; }

        public CrearClienteCommand()
        {
            TipoDocumento = default!;
            Nombres = default!;
            Apellidos = default!;
            Documento = default!;
            Email = default!;
        }
    }
}
