using Microsoft.AspNetCore.Mvc;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Aplicacion.Polizas;
using SegurosTestGAP.Aplicacion.Polizas.Comandos.Actualizar;
using SegurosTestGAP.Aplicacion.Polizas.Comandos.Borrar;
using SegurosTestGAP.Aplicacion.Polizas.Comandos.Crear;
using SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerPolizaPorId;
using SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerTodasPolizas;
using SegurosTestGAPAPI.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegurosTestGAPAPI.Polizas
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly ICommandHandler<CrearPolizaCommand, PolizaViewModel> _crearPolizaCommandHandler;
        private readonly IQueryHandler<ObtenerPolizaPorIdQuery, PolizaViewModel> _obtenerPolizaPorIdQueryQueryHandler;
        private readonly IVoidCommandHandler<BorrarPolizaPorIdCommand> _borrarPolizaPorIdCommandHandler;
        private readonly IVoidCommandHandler<ActualizarPolizaCommand> _actualizarPolizaCommandHandler;
        private readonly IQueryHandler<ObtenerPolizasQuery, IEnumerable<PolizaViewModel>> _obtenerPolizasQueryHandler;
        private readonly PolizaErrorMessages _polizaErrorMessages;

        public PolizasController(ICommandHandler<CrearPolizaCommand, PolizaViewModel> crearPolizaCommandHandler,
            IQueryHandler<ObtenerPolizaPorIdQuery, PolizaViewModel> obtenerPolizaPorIdQueryQueryHandler,
            IVoidCommandHandler<BorrarPolizaPorIdCommand> borrarPolizaPorIdCommandHandler,
            IVoidCommandHandler<ActualizarPolizaCommand> actualizarPolizaCommandHandler,
            IQueryHandler<ObtenerPolizasQuery, IEnumerable<PolizaViewModel>> obtenerPolizasQueryHandler,
            PolizaErrorMessages polizaErrorMessages)
        {
            _crearPolizaCommandHandler = crearPolizaCommandHandler;
            _obtenerPolizaPorIdQueryQueryHandler = obtenerPolizaPorIdQueryQueryHandler;
            _borrarPolizaPorIdCommandHandler = borrarPolizaPorIdCommandHandler;
            _actualizarPolizaCommandHandler = actualizarPolizaCommandHandler;
            _obtenerPolizasQueryHandler = obtenerPolizasQueryHandler;
            _polizaErrorMessages = polizaErrorMessages;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CrearPolizaCommand crearPolizaCommand)
        {
            try
            {
                var polizaCreada = await _crearPolizaCommandHandler.HandleAsync(crearPolizaCommand).ConfigureAwait(false);

                return CreatedAtAction(nameof(GetById), new { id = polizaCreada.Id }, polizaCreada);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound(new ErrorModel(nameof(_polizaErrorMessages.EntityDoesNotExist), _polizaErrorMessages.EntityDoesNotExist));
            }
            catch (EntidadYaExisteException)
            {
                return Conflict(new ErrorModel(nameof(_polizaErrorMessages.PolizaAlreadyExists), _polizaErrorMessages.PolizaAlreadyExists));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] ObtenerPolizaPorIdQuery obtenerPolizaPorIdQuery)
        {
            try
            {
                return Ok(await _obtenerPolizaPorIdQueryQueryHandler.HandleAsync(obtenerPolizaPorIdQuery).ConfigureAwait(false));
            }
            catch (EntidadNoExisteException)
            {
                return NotFound(new ErrorModel(nameof(_polizaErrorMessages.PolizaDoesNotExist), _polizaErrorMessages.PolizaDoesNotExist));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePoliza([FromRoute] int id, [FromBody] ActualizarPolizaCommand actualizarPolizaCommand)
        {
            try
            {
                actualizarPolizaCommand.Id = id;
                await _actualizarPolizaCommandHandler.HandleAsync(actualizarPolizaCommand).ConfigureAwait(false);
                return NoContent();
            }
            catch (EntidadNoExisteException)
            {
                return NotFound(new ErrorModel(nameof(_polizaErrorMessages.PolizaDoesNotExist), _polizaErrorMessages.PolizaDoesNotExist));
            }
            catch (EntidadYaExisteException)
            {
                return Conflict(new ErrorModel(nameof(_polizaErrorMessages.PolizaAlreadyExists), _polizaErrorMessages.PolizaAlreadyExists));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] BorrarPolizaPorIdCommand borrarPolizaPorIdCommand)
        {
            try
            {
                await _borrarPolizaPorIdCommandHandler.HandleAsync(borrarPolizaPorIdCommand).ConfigureAwait(false);
                return NoContent();
            }
            catch (EntidadNoExisteException)
            {
                return NotFound(new ErrorModel(nameof(_polizaErrorMessages.PolizaDoesNotExist), _polizaErrorMessages.PolizaDoesNotExist));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] ObtenerPolizasQuery obtenerPolizasQuery)
        {
            return Ok(await _obtenerPolizasQueryHandler.HandleAsync(obtenerPolizasQuery).ConfigureAwait(false));
        }

        [HttpGet]
        [Route("/SinAsignar")]
        public async Task<IActionResult> GetPolizasSinAsignar()
        {
            return Ok();
        }
    }
}