using System.Collections.Generic;
using SegurosTestGAP.Dominio.Polizas;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public class PolizaSqlGenerator : BaseSqlGenerator, IPolizaSqlGenerator
    {
        public string BuildInsertQuery()
        {
            return @"INSERT INTO [dbo].[Poliza] ([TipoRiesgoId],[TipoCubrimientoId],[Nombre],[Descripcion],[InicioVigencia],[PeriodoCobertura],[PorcentajeCobertura],[Precio])
                    VALUES (@TipoRiesgoId,@TipoCubrimientoId,@Nombre,@Descripcion,@InicioVigencia,@PeriodoCobertura,@PorcentajeCobertura,@Precio);
                    SELECT SCOPE_IDENTITY();";
        }

        public IDictionary<string, object> GetParametersForQuery(Poliza poliza)
        {
            return new Dictionary<string, object>
            {
                { "TipoRiesgoId", poliza.TipoRiesgo.Id },
                { "TipoCubrimientoId", poliza.TipoCubrimiento.Id },
                { "Nombre", poliza.Nombre },
                { "Descripcion", poliza.Descripcion },
                { "InicioVigencia", poliza.InicioVigencia },
                { "PeriodoCobertura", poliza.PeriodoCobertura },
                { "PorcentajeCobertura", poliza.PorcentajeCobertura },
                { "Precio", poliza.Precio }
            };
        }

        public string BuildExistPolizaQuery(int? id)
        {
            if (id != null)
            {
                return @"SELECT [Poliza].[TipoRiesgoId],[Poliza].[TipoCubrimientoId],[Poliza].[Nombre],[Poliza].[Descripcion],
                    [Poliza].[InicioVigencia],[Poliza].[PeriodoCobertura],
                    [Poliza].[PorcentajeCobertura],[Poliza].[Precio] FROM [dbo].[Poliza] AS [Poliza]
                    WHERE [Poliza].[TipoRiesgoId] = @TipoRiesgoId 
                    AND [Poliza].[TipoCubrimientoId] = @TipoCubrimientoId 
                    AND [Poliza].[PeriodoCobertura] = @PeriodoCobertura 
                    AND [Poliza].[PorcentajeCobertura] = @PorcentajeCobertura
                    AND [Poliza].[InicioVigencia] = @InicioVigencia
                    AND [Poliza].[Id] != @Id;";
            }
            else
            {
                return @"SELECT [Poliza].[TipoRiesgoId],[Poliza].[TipoCubrimientoId],[Poliza].[Nombre],[Poliza].[Descripcion],
                    [Poliza].[InicioVigencia],[Poliza].[PeriodoCobertura],
                    [Poliza].[PorcentajeCobertura],[Poliza].[Precio] FROM [dbo].[Poliza] AS [Poliza]
                    WHERE [Poliza].[TipoRiesgoId] = @TipoRiesgoId 
                    AND [Poliza].[TipoCubrimientoId] = @TipoCubrimientoId 
                    AND [Poliza].[PeriodoCobertura] = @PeriodoCobertura 
                    AND [Poliza].[PorcentajeCobertura] = @PorcentajeCobertura
                    AND [Poliza].[InicioVigencia] = @InicioVigencia;";
            }
            
        }

        public string BuildGetAllSqlQuery()
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
                INNER JOIN [dbo].[TipoRiesgo] AS [TipoRiesgo] ON [TipoRiesgo].[Id] = [Poliza].[TipoRiesgoId];";
        }
    }
}
