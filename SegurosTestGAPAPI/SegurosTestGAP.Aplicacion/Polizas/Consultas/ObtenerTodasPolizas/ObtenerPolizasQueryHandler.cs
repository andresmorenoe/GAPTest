using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerTodasPolizas
{
    public class ObtenerPolizasQueryHandler : IQueryHandler<ObtenerPolizasQuery, IEnumerable<PolizaViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerPolizasQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<PolizaViewModel>> HandleAsync(ObtenerPolizasQuery query)
        {
            var polizas = await _unitOfWork.Polizas.GetAllPolizasAsync().ConfigureAwait(false);

            return polizas.Select(poliza => new PolizaViewModel(poliza.Id, 
                poliza.Nombre, poliza.Descripcion, poliza.InicioVigencia, poliza.PeriodoCobertura, poliza.PorcentajeCobertura, poliza.Precio
                , poliza.TipoRiesgo.Nombre, poliza.TipoCubrimiento.Nombre));
        }
    }
}
