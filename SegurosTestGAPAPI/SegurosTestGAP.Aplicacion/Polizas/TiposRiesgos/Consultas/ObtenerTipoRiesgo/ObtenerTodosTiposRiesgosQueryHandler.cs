using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.TiposRiesgos.Consultas.ObtenerTipoRiesgo
{
    public class ObtenerTodosTiposRiesgosQueryHandler : IQueryHandler<ObtenerTodosTiposRiesgosQuery, IEnumerable<TipoRiesgoViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerTodosTiposRiesgosQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<TipoRiesgoViewModel>> HandleAsync(ObtenerTodosTiposRiesgosQuery query)
        {
            var tiposRiesgos = await _unitOfWork.TiposRiesgos.GetAllAsync().ConfigureAwait(false);

            return tiposRiesgos.Select(tipo => new TipoRiesgoViewModel(tipo.Nombre));
        }
    }
}
