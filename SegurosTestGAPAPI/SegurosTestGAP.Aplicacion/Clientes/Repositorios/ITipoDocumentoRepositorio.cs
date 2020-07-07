using SegurosTestGAP.Dominio.Clientes;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Clientes.Repositorios
{
    public interface ITipoDocumentoRepositorio : IRepository<TipoDocumento>
    {
        Task<TipoDocumento> GetByNameAsync(string nombre);
    }
}
