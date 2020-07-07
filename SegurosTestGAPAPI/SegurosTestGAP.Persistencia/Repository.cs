using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Dominio;
using SegurosTestGAP.Persistencia.SqlGenerator;

namespace SegurosTestGAP.Persistencia
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        private readonly IDbConnection _connection;
        private readonly ISqlGenerator _sqlGenerator;

        public Repository(IDbConnection connection, ISqlGenerator sqlGenerator) => (_connection, _sqlGenerator) = (connection, sqlGenerator);

        public void Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var selectAllQuery = _sqlGenerator.BuildGetAllSqlQuery(typeof(TEntity).Name);
            var resultSet = (await _connection.QueryAsync<TEntity>(selectAllQuery).ConfigureAwait(false)).ToList();
            
            return resultSet;
        }

        public void Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var deleteQuery = _sqlGenerator.BuildDeleteSqlCommand(typeof(TEntity).Name, id, out var outputParameters);
            await _connection.ExecuteAsync(deleteQuery, outputParameters).ConfigureAwait(false);
        }

        Task<TEntity> IRepository<TEntity>.GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
