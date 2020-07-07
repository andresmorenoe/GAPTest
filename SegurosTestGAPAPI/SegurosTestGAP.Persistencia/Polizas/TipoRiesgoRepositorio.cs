using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Aplicacion.Polizas.Repositorios;
using SegurosTestGAP.Dominio.Polizas;
using SegurosTestGAP.Persistencia.SqlGenerator;

namespace SegurosTestGAP.Persistencia.Polizas
{
    public class TipoRiesgoRepositorio : Repository<TipoRiesgo>, ITipoRiesgoRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly ITipoRiesgoSqlGenerator _sqlGenerator;

        public TipoRiesgoRepositorio(IDbConnection connection,
            ITipoRiesgoSqlGenerator sqlGenerator) : base(connection, sqlGenerator)
        {
            _connection = connection;
            _sqlGenerator = sqlGenerator;
        }

        public async Task<TipoRiesgo> GetByNameAsync(string nombre)
        {
            var getByNameSqlQuery = _sqlGenerator.BuildGetByNameSqlQuery();
            var results = (await _connection.QueryAsync<TipoRiesgo>(getByNameSqlQuery, new { Nombre = nombre }).ConfigureAwait(false)).ToList();

            if (!results.Any())
            {
                throw new EntidadNoExisteException($"{nameof(TipoRiesgo)} does not exist.");
            }

            var entityResult = results.Single();
            return entityResult;
        }
    }
}
