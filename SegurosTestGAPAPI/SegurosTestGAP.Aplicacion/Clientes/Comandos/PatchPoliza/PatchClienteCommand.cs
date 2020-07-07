using System.Collections.Generic;

namespace SegurosTestGAP.Aplicacion.Clientes.Comandos.PatchPoliza
{
    public class PatchClienteCommand : ICommand
    {
        public int ClienteId { get; set; }

        public IEnumerable<int> Add { get; set; }

        public IEnumerable<int> Remove { get; set; }

        public PatchClienteCommand() => (Add, Remove) = (new List<int>(), new List<int>());
    }
}
