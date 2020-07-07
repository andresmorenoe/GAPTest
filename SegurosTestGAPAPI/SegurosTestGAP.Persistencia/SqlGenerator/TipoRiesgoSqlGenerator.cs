using SegurosTestGAP.Dominio.Polizas;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public class TipoRiesgoSqlGenerator : BaseSqlGenerator, ITipoRiesgoSqlGenerator
    {
        public string BuildGetByNameSqlQuery()
        {
            return @$"SELECT [TipoRiesgo].[Id], [TipoRiesgo].[Nombre] 
                    FROM [{nameof(TipoRiesgo)}] AS TipoRiesgo 
                    WHERE [TipoRiesgo].[Nombre] = @Nombre";
        }
    }
}
