using SegurosTestGAP.Dominio.Clientes;
using SegurosTestGAP.Dominio.Polizas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Clientes.Repositorios
{
    public interface IClienteRepositorio : IRepository<Cliente>
    {
        Task<bool> ExistByDocumentAsync(string documento);

        Task<Cliente> InsertCliente(Cliente cliente);

        Task<Cliente> GetClienteById(int Id);
        Task RemoverPolizas(List<AsignacionPoliza> removerPolizas);
        Task AsignarPolizas(List<AsignacionPoliza> asignarPolizas);
    }
}
