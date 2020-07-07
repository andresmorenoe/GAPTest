using SegurosTestGAP.Dominio.Clientes;

namespace SegurosTestGAP.Dominio.Polizas
{
    public class AsignacionPoliza : Entity
    {
        public Cliente Cliente { get; set; }

        public Poliza Poliza { get; set; }

        public AsignacionPoliza() => (Cliente, Poliza) = (default!, default!);

        public AsignacionPoliza(Cliente cliente, Poliza poliza) => (Cliente, Poliza) = (cliente, poliza);
    }
}
