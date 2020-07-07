using SegurosTestGAP.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Add(TEntity entity);

        void Remove(TEntity entity);

        Task RemoveByIdAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
