using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Clientes.TiposDocumentos;
using SegurosTestGAP.Aplicacion.Clientes.TiposDocumentos.Consultas.ObtenerTipoDocumento;

namespace SegurosTestGAPAPI.Clientes
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TipoDocumentosController : ControllerBase
    {
        private readonly IQueryHandler<ObtenerTodosTiposDocumentoQuery, IEnumerable<TipoDocumentoViewModel>> _obtenerTodosTiposDocumentoQueryHandler;

        public TipoDocumentosController(IQueryHandler<ObtenerTodosTiposDocumentoQuery, IEnumerable<TipoDocumentoViewModel>> obtenerTodosTiposDocumentoQueryHandler)
        {
            _obtenerTodosTiposDocumentoQueryHandler = obtenerTodosTiposDocumentoQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTipoDocumentos([FromQuery] ObtenerTodosTiposDocumentoQuery obtenerTodosTiposDocumentoQuery)
        {
            return Ok(await _obtenerTodosTiposDocumentoQueryHandler.HandleAsync(obtenerTodosTiposDocumentoQuery).ConfigureAwait(false));
        }
    }
}