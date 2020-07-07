using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Polizas;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Comandos.Borrar
{
    public class BorrarPolizaPorIdCommandHandler : IVoidCommandHandler<BorrarPolizaPorIdCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public BorrarPolizaPorIdCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task HandleAsync(BorrarPolizaPorIdCommand command)
        {
            Poliza poliza;
            try
            {
                poliza = await _unitOfWork.Polizas.GetByIdAsync(command.Id).ConfigureAwait(false);
                await _unitOfWork.Polizas.RemoveByIdAsync(poliza.Id).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {

                throw new EntidadNoExisteException($"La poliza {command.Id} no existe");
            }
        }
    }
}
