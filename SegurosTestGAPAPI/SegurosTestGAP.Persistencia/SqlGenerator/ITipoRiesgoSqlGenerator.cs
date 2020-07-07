namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public interface ITipoRiesgoSqlGenerator : ISqlGenerator
    {
        string BuildGetByNameSqlQuery();
    }
}
