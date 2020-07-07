using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Polizas;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Comandos.Actualizar
{
    public class ActualizarPolizaCommandHandler : IVoidCommandHandler<ActualizarPolizaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarPolizaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task HandleAsync(ActualizarPolizaCommand command)
        {
            Poliza poliza;
            try
            {
                poliza = await _unitOfWork.Polizas.GetByIdAsync(command.Id).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {

                throw new EntidadNoExisteException($"La poliza {command.Id} no existe");
            }

            TipoCubrimiento tipoCubrimiento;
            try
            {
                tipoCubrimiento = await _unitOfWork.TiposCubrimientos.GetByNameAsync(command.TipoCubrimiento).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {

                throw new EntidadNoExisteException($"El tipo de cubrimiento {command.TipoCubrimiento} no existe");
            }

            TipoRiesgo tipoRiesgo;
            try
            {
                tipoRiesgo = await _unitOfWork.TiposRiesgos.GetByNameAsync(command.TipoRiesgo).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {

                throw new EntidadNoExisteException($"El tipo de riesgo {command.TipoRiesgo} no existe");
            }

            var polizaActualizar = new Poliza(command.Nombre, command.Descripcion, command.InicioVigencia,
                command.PeriodoCobertura, command.PorcentajeCobertura, command.Precio, tipoRiesgo, tipoCubrimiento);

            if (await _unitOfWork.Polizas.ExistPolizaAsync(tipoRiesgo.Id, tipoCubrimiento.Id, polizaActualizar.PeriodoCobertura, polizaActualizar.PorcentajeCobertura, polizaActualizar.InicioVigencia, command.Id))
            {
                throw new EntidadYaExisteException($"La poliza con los siguientes datos: {command.TipoRiesgo},  {command.TipoCubrimiento} ya existe");
            }

            await _unitOfWork.Polizas.ActualizarPoliza(command.Id, polizaActualizar);
        }
    }
}
