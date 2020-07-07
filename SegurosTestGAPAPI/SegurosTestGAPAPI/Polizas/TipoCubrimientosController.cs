using Microsoft.AspNetCore.Mvc;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Polizas.TiposCubrimientos;
using SegurosTestGAP.Aplicacion.Polizas.TiposCubrimientos.Consultas.ObtenerTipoCubrimiento;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegurosTestGAPAPI.Polizas
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TipoCubrimientosController : ControllerBase
    {
        private readonly IQueryHandler<ObtenerTodosTiposCubrimientosQuery, IEnumerable<TipoCubrimientoViewModel>> _obtenerTodosTiposCubrimientosQueryHandler;

        public TipoCubrimientosController(IQueryHandler<ObtenerTodosTiposCubrimientosQuery, IEnumerable<TipoCubrimientoViewModel>> obtenerTodosTiposCubrimientosQueryHandler)
        {
            _obtenerTodosTiposCubrimientosQueryHandler = obtenerTodosTiposCubrimientosQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTipoCubrimientos([FromQuery] ObtenerTodosTiposCubrimientosQuery obtenerTodosTiposCubrimientosQuery)
        {
            return Ok(await _obtenerTodosTiposCubrimientosQueryHandler.HandleAsync(obtenerTodosTiposCubrimientosQuery).ConfigureAwait(false));
        }
    }
}