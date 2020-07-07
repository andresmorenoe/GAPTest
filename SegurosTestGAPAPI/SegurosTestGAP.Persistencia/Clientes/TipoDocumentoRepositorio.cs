using Dapper;
using SegurosTestGAP.Aplicacion.Clientes.Repositorios;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Clientes;
using SegurosTestGAP.Persistencia.SqlGenerator;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Persistencia.Clientes
{
    public class TipoDocumentoRepositorio : Repository<TipoDocumento>, ITipoDocumentoRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly ITipoDocumentoSqlGenerator _sqlGenerator;

        public TipoDocumentoRepositorio(IDbConnection connection,
            ITipoDocumentoSqlGenerator sqlGenerator) : base (connection, sqlGenerator)
        {
            _connection = connection;
            _sqlGenerator = sqlGenerator;
        }

        public Task<bool> ExistByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TipoDocumento> GetByNameAsync(string nombre)
        {
            var getByNameSqlQuery = _sqlGenerator.BuildGetByNameSqlQuery();
            var results = (await _connection.QueryAsync<TipoDocumento>(getByNameSqlQuery, new { Nombre = nombre }).ConfigureAwait(false)).ToList();

            if (!results.Any())
            {
                throw new EntidadNoExisteException($"{nameof(TipoDocumento)} does not exist.");
            }

            var entityResult = results.Single();
            return entityResult;
        }
    }
}
