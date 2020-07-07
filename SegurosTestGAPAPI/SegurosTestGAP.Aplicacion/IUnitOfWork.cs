using SegurosTestGAP.Aplicacion.Clientes.Repositorios;
using SegurosTestGAP.Aplicacion.Polizas.Repositorios;

namespace SegurosTestGAP.Aplicacion
{
    public interface IUnitOfWork
    {
        ITipoDocumentoRepositorio TiposDocumentos { get; }

        IClienteRepositorio Clientes { get; }

        ITipoRiesgoRepositorio TiposRiesgos { get; }

        ITipoCubrimientoRepositorio TiposCubrimientos { get; }

        IPolizaRepositorio Polizas { get; }
    }
}
