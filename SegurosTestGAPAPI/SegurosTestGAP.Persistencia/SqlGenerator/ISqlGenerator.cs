using SegurosTestGAP.Dominio;
using SegurosTestGAP.Dominio.Polizas;
using System.Collections.Generic;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public interface ISqlGenerator
    {
        string BuildAddSqlCommand(IEntity entity);

        string BuildUpdateSqlCommand(string nombreTabla, int id, Poliza poliza, out IDictionary<string, object> outputParameters);

        string BuildGetAllSqlQuery(string nombreTabla);

        string BuildGetByNameSqlQuery(string nombreTabla);

        string BuildDeleteSqlCommand(string nombreTabla, int id, out IDictionary<string, object> outputParameters);
        
        string BuildGetByIdSqlQuery();
    }
}
