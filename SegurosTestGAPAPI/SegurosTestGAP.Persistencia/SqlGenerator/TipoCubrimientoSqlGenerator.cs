using SegurosTestGAP.Dominio.Polizas;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public class TipoCubrimientoSqlGenerator : BaseSqlGenerator, ITipoCubrimientoSqlGenerator
    {
        public string BuildGetByNameSqlQuery()
        {
            return @$"SELECT [TipoCubrimiento].[Id], [TipoCubrimiento].[Nombre] 
                    FROM [{nameof(TipoCubrimiento)}] AS TipoCubrimiento 
                    WHERE [TipoCubrimiento].[Nombre] = @Nombre";
        }
    }
}
