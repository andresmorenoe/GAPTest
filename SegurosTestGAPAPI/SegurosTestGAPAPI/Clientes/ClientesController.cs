using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Clientes.Comandos;
using SegurosTestGAP.Aplicacion.Clientes.Comandos.Crear;
using SegurosTestGAP.Aplicacion.Clientes.Comandos.PatchPoliza;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAPAPI.General;

namespace SegurosTestGAPAPI.Clientes
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ICommandHandler<CrearClienteCommand, ClienteViewModel> _crearClienteCommandHandler;
        private readonly IVoidCommandHandler<PatchClienteCommand> _patchClienteCommandHandler;
        private readonly ClienteErrorMessages _clienteErrorMessages;

        public ClientesController(ICommandHandler<CrearClienteCommand, ClienteViewModel> crearClienteCommandHandler,
            IVoidCommandHandler<PatchClienteCommand> patchClienteCommandHandler,
            ClienteErrorMessages clienteErrorMessages)
        {
            _crearClienteCommandHandler = crearClienteCommandHandler;
            _patchClienteCommandHandler = patchClienteCommandHandler;
            _clienteErrorMessages = clienteErrorMessages;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CrearClienteCommand crearClienteCommand)
        {
            try
            {
                var clientCreado = await _crearClienteCommandHandler.HandleAsync(crearClienteCommand).ConfigureAwait(false);

                return CreatedAtAction(nameof(GetById), new { id = clientCreado.Id }, clientCreado);
            }
            catch (EntidadNoExisteException)
            {
                return NotFound(new ErrorModel(nameof(_clienteErrorMessages.EntityDoesNotExist), _clienteErrorMessages.EntityDoesNotExist));
            }
            catch (EntidadYaExisteException)
            {
                return Conflict(new ErrorModel(nameof(_clienteErrorMessages.ClienteAlreadyExists), _clienteErrorMessages.ClienteAlreadyExists));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById()
        {
            return Ok();        
        }

        [HttpPatch]
        [Route("{id}/polizas")]
        public async Task<ActionResult> Patch([FromRoute] int id, [FromBody] PatchClienteCommand patchClienteCommand)
        {
            try
            {
                patchClienteCommand.ClienteId = id;
                await _patchClienteCommandHandler.HandleAsync(patchClienteCommand).ConfigureAwait(false);

                return Ok();
            }
            catch (EntidadYaExisteException)
            {
                return Conflict(new ErrorModel(nameof(_clienteErrorMessages.ClienteAlreadyExists), _clienteErrorMessages.ClienteAlreadyExists));
            }
            catch (EntidadNoExisteException)
            {
                return NotFound(new ErrorModel(nameof(_clienteErrorMessages.ClienteDoesNotExist), _clienteErrorMessages.ClienteDoesNotExist));
            }
        }

        [HttpGet]
        [Route("{id}/polizas")]
        public async Task<IActionResult> GetPolizasByClientId()
        {
            return Ok();
        }
    }
}