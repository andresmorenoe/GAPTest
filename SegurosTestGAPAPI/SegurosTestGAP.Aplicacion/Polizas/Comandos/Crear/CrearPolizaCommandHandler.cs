using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Polizas;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Comandos.Crear
{
    public class CrearPolizaCommandHandler : ICommandHandler<CrearPolizaCommand, PolizaViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CrearPolizaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PolizaViewModel> HandleAsync(CrearPolizaCommand command)
        {
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

            var poliza = new Poliza(command.Nombre, command.Descripcion, command.InicioVigencia,
                command.PeriodoCobertura, command.PorcentajeCobertura, command.Precio, tipoRiesgo, tipoCubrimiento);

            if (await _unitOfWork.Polizas.ExistPolizaAsync(poliza.TipoRiesgo.Id, poliza.TipoCubrimiento.Id, poliza.PeriodoCobertura, poliza.PorcentajeCobertura, poliza.InicioVigencia, null))
            {
                throw new EntidadYaExisteException($"La poliza con los siguientes datos: {command.TipoRiesgo},  {command.TipoCubrimiento}ya existe");
            }

            await _unitOfWork.Polizas.InsertPoliza(poliza).ConfigureAwait(false);

            return new PolizaViewModel(poliza.Id, poliza.Nombre, poliza.Descripcion, poliza.InicioVigencia, poliza.PeriodoCobertura, poliza.PorcentajeCobertura, poliza.Precio, poliza.TipoRiesgo.Nombre, poliza.TipoCubrimiento.Nombre);
        }
    }
}
