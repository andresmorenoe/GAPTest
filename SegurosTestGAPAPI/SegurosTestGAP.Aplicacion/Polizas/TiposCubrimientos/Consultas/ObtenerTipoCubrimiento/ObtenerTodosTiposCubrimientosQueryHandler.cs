using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.TiposCubrimientos.Consultas.ObtenerTipoCubrimiento
{
    public class ObtenerTodosTiposCubrimientosQueryHandler : IQueryHandler<ObtenerTodosTiposCubrimientosQuery, IEnumerable<TipoCubrimientoViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerTodosTiposCubrimientosQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<TipoCubrimientoViewModel>> HandleAsync(ObtenerTodosTiposCubrimientosQuery query)
        {
            var tiposCubrimientos = await _unitOfWork.TiposCubrimientos.GetAllAsync().ConfigureAwait(false);

            return tiposCubrimientos.Select(tipo => new TipoCubrimientoViewModel(tipo.Nombre));
        }
    }
}
