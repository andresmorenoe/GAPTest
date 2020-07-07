using SegurosTestGAP.Dominio.Polizas;
using System.Collections.Generic;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public interface IPolizaSqlGenerator : ISqlGenerator
    {
        IDictionary<string, object> GetParametersForQuery(Poliza poliza);

        string BuildInsertQuery();

        string BuildExistPolizaQuery(int? id);

        string BuildGetAllSqlQuery();
    }
}
