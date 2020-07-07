using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Clientes;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Clientes.Comandos.Crear
{
    public class CrearClienteCommandHandler : ICommandHandler<CrearClienteCommand, ClienteViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearClienteCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ClienteViewModel> HandleAsync(CrearClienteCommand command)
        {
            TipoDocumento tipoDocumento;
            try
            {
                tipoDocumento = await _unitOfWork.TiposDocumentos.GetByNameAsync(command.TipoDocumento).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {

                throw new EntidadNoExisteException($"El tipo de documento {command.TipoDocumento} no existe");
            }

            if (await _unitOfWork.Clientes.ExistByDocumentAsync(command.Documento))
            {
                throw new EntidadYaExisteException($"El cliente con documento: {command.Documento} ya existe");
            }

            var cliente = new Cliente(command.Nombres, command.Apellidos, command.Documento, command.Email, tipoDocumento);

            await _unitOfWork.Clientes.InsertCliente(cliente).ConfigureAwait(false);

            return new ClienteViewModel(cliente.Id, cliente.Nombres, cliente.Apellidos, cliente.Documento, cliente.Email, cliente.TipoDocumento.Nombre);
        }
    }
}
