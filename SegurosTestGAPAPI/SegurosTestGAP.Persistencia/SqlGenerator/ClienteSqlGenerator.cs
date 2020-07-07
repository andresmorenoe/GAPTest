using SegurosTestGAP.Dominio.Clientes;
using System.Collections.Generic;

namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public class ClienteSqlGenerator : BaseSqlGenerator, IClienteSqlGenerator
    {
        public string BuildExistClienteQuery()
        {
            return @"SELECT [Cliente].[Id],[Cliente].[TipoDocumentoId],[Cliente].[Nombres],[Cliente].[Apellidos],[Cliente].[Documento],
                    [Cliente].[Email] FROM [dbo].[Cliente] AS [Cliente]
                    WHERE [Cliente].[Documento] = @Documento;";
        }

        public string BuildGetClientByCode()
        {
            throw new System.NotImplementedException();
        }

        public string BuildGetClientByIdSqlQuery()
        {
            return $@"SELECT [Cliente].[Id]
                ,[Cliente].[TipoDocumentoId]
                ,[Cliente].[Nombres]
                ,[Cliente].[Apellidos]
                ,[Cliente].[Documento]
                ,[Cliente].[Email]
                ,[TipoDocumento].[Id]
                ,[TipoDocumento].[Nombre]
                FROM [dbo].[Cliente] AS [Cliente] 
                INNER JOIN [dbo].[TipoDocumento] AS [TipoDocumento] ON [TipoDocumento].[Id] = [Cliente].[TipoDocumentoId]
                WHERE [Cliente].[Id] = @Id";
        }

        public string BuildInsertAsigacionQuery()
        {
            return @"INSERT INTO [dbo].[AsignacionPoliza] ([ClienteId],[PolizaId])
                    VALUES (@ClienteId,@PolizaId);";
        }

        public string BuildInsertQuery()
        {
            return @"INSERT INTO [dbo].[Cliente] ([TipoDocumentoId],[Nombres],[Apellidos],[Documento],[Email])
                    VALUES (@TipoDocumentoId,@Nombres,@Apellidos,@Documento,@Email);
                    SELECT SCOPE_IDENTITY();";
        }

        public IDictionary<string, object> GetParametersForQuery(Cliente cliente)
        {
            return new Dictionary<string, object>
            {
                { "TipoDocumentoId", cliente.TipoDocumento.Id },
                { "Nombres", cliente.Nombres },
                { "Apellidos", cliente.Apellidos },
                { "Documento", cliente.Documento },
                { "Email", cliente.Email }
            };
        }

        public string BuildRemoverAsigacionQuery()
        {
            return @"DELETE FROM [dbo].[AsignacionPoliza] WHERE [ClienteId] = @ClienteId AND [PolizaId] = @PolizaId;";
        }
    }
}
