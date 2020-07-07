using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Clientes.Repositorios;
using SegurosTestGAP.Aplicacion.Polizas.Repositorios;
using SegurosTestGAP.Persistencia.SqlGenerator;
using System.Data;

namespace SegurosTestGAP.Persistencia
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly ISqlGenerator _sqlGeneratorBase;
        public ITipoDocumentoRepositorio TiposDocumentos { get; }
        public IClienteRepositorio Clientes { get; }
        public ITipoRiesgoRepositorio TiposRiesgos { get; }
        public ITipoCubrimientoRepositorio TiposCubrimientos { get; }
        public IPolizaRepositorio Polizas { get; }

        public UnitOfWork(IDbConnection connection,
            ISqlGenerator sqlGeneratorBase,
            ITipoDocumentoRepositorio tiposDocumentos,
            IClienteRepositorio clientes,
            ITipoRiesgoRepositorio tiposRiesgos,
            ITipoCubrimientoRepositorio tiposCubrimientos,
            IPolizaRepositorio polizas)
        {
            _connection = connection;
            _sqlGeneratorBase = sqlGeneratorBase;
            TiposDocumentos = tiposDocumentos;
            Clientes = clientes;
            TiposRiesgos = tiposRiesgos;
            TiposCubrimientos = tiposCubrimientos;
            Polizas = polizas;
        }
    }
}
