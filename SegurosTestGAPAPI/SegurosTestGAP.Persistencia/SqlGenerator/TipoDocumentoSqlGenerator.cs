using SegurosTestGAP.Dominio.Clientes;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public class TipoDocumentoSqlGenerator : BaseSqlGenerator, ITipoDocumentoSqlGenerator
    {
        public string BuildGetByNameSqlQuery()
        {
            return @$"SELECT [TipoDocumento].[Id], [TipoDocumento].[Nombre] 
                    FROM [{nameof(TipoDocumento)}] AS TipoDocumento 
                    WHERE [TipoDocumento].[Nombre] = @Nombre";
        }
    }
}
