using SegurosTestGAP.Dominio.Polizas;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Repositorios
{
    public interface ITipoRiesgoRepositorio : IRepository<TipoRiesgo>
    {
        Task<TipoRiesgo> GetByNameAsync(string nombre);
    }
}
