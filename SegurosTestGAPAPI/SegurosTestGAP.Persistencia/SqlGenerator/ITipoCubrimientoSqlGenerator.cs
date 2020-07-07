namespace SegurosTestGAP.Persistencia.SqlGenerator
{
    public interface ITipoCubrimientoSqlGenerator : ISqlGenerator
    {
        string BuildGetByNameSqlQuery();
    }
}
