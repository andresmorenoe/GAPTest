namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public interface ITipoDocumentoSqlGenerator : ISqlGenerator
    {
        string BuildGetByNameSqlQuery();
    }
}
