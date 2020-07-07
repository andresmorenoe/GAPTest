using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Clientes.TiposDocumentos.Consultas.ObtenerTipoDocumento
{
    public class ObtenerTodosTiposDocumentoQueryHandler : IQueryHandler<ObtenerTodosTiposDocumentoQuery, IEnumerable<TipoDocumentoViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObtenerTodosTiposDocumentoQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<TipoDocumentoViewModel>> HandleAsync(ObtenerTodosTiposDocumentoQuery query)
        {
            var tiposDocumentos = await _unitOfWork.TiposDocumentos.GetAllAsync().ConfigureAwait(false);

            return tiposDocumentos.Select(tipo => new TipoDocumentoViewModel(tipo.Nombre));
        }
    }
}
