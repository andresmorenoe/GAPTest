using SegurosTestGAP.Dominio.Clientes;
using System.Collections.Generic;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public interface IClienteSqlGenerator : ISqlGenerator
    {
        string BuildGetClientByCode();

        string BuildExistClienteQuery();

        IDictionary<string, object> GetParametersForQuery(Cliente cliente);

        string BuildInsertQuery();

        string BuildGetClientByIdSqlQuery();

        string BuildInsertAsigacionQuery();

        string BuildRemoverAsigacionQuery();
    }
}
