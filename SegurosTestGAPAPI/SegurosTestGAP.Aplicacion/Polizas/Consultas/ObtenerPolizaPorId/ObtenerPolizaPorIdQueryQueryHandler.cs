using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Polizas;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerPolizaPorId
{
    public class ObtenerPolizaPorIdQueryQueryHandler : IQueryHandler<ObtenerPolizaPorIdQuery, PolizaViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerPolizaPorIdQueryQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<PolizaViewModel> HandleAsync(ObtenerPolizaPorIdQuery query)
        {
            Poliza poliza;
            try
            {
                poliza = await _unitOfWork.Polizas.GetByIdAsync(query.Id).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {

                throw new EntidadNoExisteException($"La poliza {query.Id} no existe");
            }

            return new PolizaViewModel(query.Id, poliza.Nombre, poliza.Descripcion, poliza.InicioVigencia, poliza.PeriodoCobertura, poliza.PorcentajeCobertura, poliza.Precio, poliza.TipoRiesgo.Nombre, poliza.TipoCubrimiento.Nombre);
        }
    }
}
