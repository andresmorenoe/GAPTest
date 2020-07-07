using Dapper;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Aplicacion.Polizas.Repositorios;
using SegurosTestGAP.Dominio.Polizas;
using SegurosTestGAP.Persistencia.SqlGenerator;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Persistencia.Polizas
{
    public class TipoCubrimientoRepositorio : Repository<TipoCubrimiento>, ITipoCubrimientoRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly ITipoCubrimientoSqlGenerator _sqlGenerator;

        public TipoCubrimientoRepositorio(IDbConnection connection,
            ITipoCubrimientoSqlGenerator sqlGenerator) : base(connection, sqlGenerator)
        {
            _connection = connection;
            _sqlGenerator = sqlGenerator;
        }

        public async Task<TipoCubrimiento> GetByNameAsync(string nombre)
        {
            var getByNameSqlQuery = _sqlGenerator.BuildGetByNameSqlQuery();
            var results = (await _connection.QueryAsync<TipoCubrimiento>(getByNameSqlQuery, new { Nombre = nombre }).ConfigureAwait(false)).ToList();

            if (!results.Any())
            {
                throw new EntidadNoExisteException($"{nameof(TipoCubrimiento)} does not exist.");
            }

            var entityResult = results.Single();
            return entityResult;
        }
    }
}
