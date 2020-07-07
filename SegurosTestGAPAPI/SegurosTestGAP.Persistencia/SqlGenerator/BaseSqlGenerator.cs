using System.Collections.Generic;
using SegurosTestGAP.Dominio;
using SegurosTestGAP.Dominio.Polizas;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public class BaseSqlGenerator : ISqlGenerator
    {
        public string BuildAddSqlCommand(IEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public string BuildDeleteSqlCommand(string nombreTabla, int id, out IDictionary<string, object> outputParameters)
        {
            outputParameters = new Dictionary<string, object> { { "p1", id } };

            return $"DELETE FROM [dbo].[{nombreTabla}] WHERE [Id] = @p1;";
        }

        public string BuildGetAllSqlQuery(string nombreTabla)
        {
            return @$"SELECT [Id], [Nombre] 
                    FROM [{nombreTabla}] ORDER BY [Id] ASC;" ;
        }

        public string BuildGetByIdSqlQuery()
        {
            return $@"SELECT [Poliza].[Id] ,[Poliza].[TipoRiesgoId]
                ,[Poliza].[TipoCubrimientoId]
                ,[Poliza].[Nombre]
                ,[Poliza].[Descripcion]
                ,[Poliza].[InicioVigencia]
                ,[Poliza].[PeriodoCobertura]
                ,[Poliza].[PorcentajeCobertura]
                ,[Poliza].[Precio]
                ,[TipoCubrimiento].[Id]
                ,[TipoCubrimiento].[Nombre]
                ,[TipoRiesgo].[Id]
                ,[TipoRiesgo].[Nombre]
                FROM [dbo].[Poliza] AS [Poliza] 
                INNER JOIN [dbo].[TipoCubrimiento] AS [TipoCubrimiento] ON [TipoCubrimiento].[Id] = [Poliza].[TipoCubrimientoId]
                INNER JOIN [dbo].[TipoRiesgo] AS [TipoRiesgo] ON [TipoRiesgo].[Id] = [Poliza].[TipoRiesgoId]
                WHERE [Poliza].[Id] = @Id";
        }

        public string BuildGetByNameSqlQuery(string nombreTabla)
        {
            return @$"SELECT [{nombreTabla}].[Id], [{nombreTabla}].[Nombre] 
                    FROM [{nombreTabla}] AS {nombreTabla} 
                    WHERE [{nombreTabla}].[Nombre] = @Nombre";
        }

        public string BuildUpdateSqlCommand(string nombreTabla, int id, Poliza poliza, out IDictionary<string, object> outputParameters)
        {
            outputParameters = new Dictionary<string, object> 
            {
                { "TipoRiesgoId", poliza.TipoRiesgo.Id },
                { "TipoCubrimientoId", poliza.TipoCubrimiento.Id },
                { "Nombre", poliza.Nombre },
                { "Descripcion", poliza.Descripcion },
                { "InicioVigencia", poliza.InicioVigencia },
                { "PeriodoCobertura", poliza.PeriodoCobertura },
                { "PorcentajeCobertura", poliza.PorcentajeCobertura },
                { "Precio", poliza.Precio },
                { "p1", id } 
            };

            return $"UPDATE [dbo].[{nombreTabla}] SET " +
                "[TipoRiesgoId] = @TipoRiesgoId " +
                ",[TipoCubrimientoId] = @TipoCubrimientoId " +
                " ,[Nombre] = @Nombre " +
                " ,[Descripcion] = @Descripcion " +
                " ,[InicioVigencia] = @InicioVigencia " +
                " ,[PeriodoCobertura] = @PeriodoCobertura " +
                " ,[PorcentajeCobertura] = @PorcentajeCobertura " +
                " ,[Precio] = @Precio " +
                $"WHERE [Id] = @p1;";
        }
    }
}
