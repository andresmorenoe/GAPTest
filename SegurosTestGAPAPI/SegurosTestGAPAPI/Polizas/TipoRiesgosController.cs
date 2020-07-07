using Microsoft.AspNetCore.Mvc;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Polizas.TiposRiesgos;
using SegurosTestGAP.Aplicacion.Polizas.TiposRiesgos.Consultas.ObtenerTipoRiesgo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegurosTestGAPAPI.Polizas
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TipoRiesgosController : ControllerBase
    {
        private readonly IQueryHandler<ObtenerTodosTiposRiesgosQuery, IEnumerable<TipoRiesgoViewModel>> _obtenerTodosTiposRiesgosQueryHandler;

        public TipoRiesgosController(IQueryHandler<ObtenerTodosTiposRiesgosQuery, IEnumerable<TipoRiesgoViewModel>> obtenerTodosTiposRiesgosQueryHandler)
        {
            _obtenerTodosTiposRiesgosQueryHandler = obtenerTodosTiposRiesgosQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTipoRiesgos([FromQuery] ObtenerTodosTiposRiesgosQuery obtenerTodosTiposRiesgosQuery)
        {
            return Ok(await _obtenerTodosTiposRiesgosQueryHandler.HandleAsync(obtenerTodosTiposRiesgosQuery).ConfigureAwait(false));
        }
    }
}