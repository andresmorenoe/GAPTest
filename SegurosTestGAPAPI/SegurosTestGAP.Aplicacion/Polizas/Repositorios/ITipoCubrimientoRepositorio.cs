using SegurosTestGAP.Dominio.Polizas;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Repositorios
{
    public interface ITipoCubrimientoRepositorio : IRepository<TipoCubrimiento>
    {
        Task<TipoCubrimiento> GetByNameAsync(string nombre);
    }
}
