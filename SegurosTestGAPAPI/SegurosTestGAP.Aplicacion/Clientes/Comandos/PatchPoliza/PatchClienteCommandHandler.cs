using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Clientes;
using SegurosTestGAP.Dominio.Polizas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Clientes.Comandos.PatchPoliza
{
    public class PatchClienteCommandHandler : IVoidCommandHandler<PatchClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatchClienteCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task HandleAsync(PatchClienteCommand command)
        {
            Cliente cliente;
            try
            {
                cliente = await _unitOfWork.Clientes.GetClienteById(command.ClienteId).ConfigureAwait(false);
            }
            catch (EntidadNoExisteException)
            {
                throw new EntidadNoExisteException($"El cliente {command.ClienteId} does not exist");
            }
            if (command.Add.Any())
            {
                try
                { 
                    await ExecuteAddPolizas(cliente, command.Add).ConfigureAwait(false);
                }
                catch (EntidadNoExisteException)
                {
                    throw new EntidadNoExisteException($"Alguna de las polizas no existe");
                }
            }

            if (command.Remove.Any())
            {
                try
                {
                    await ExecuteRemovePolizas(cliente, command.Remove).ConfigureAwait(false);
                }
                catch (EntidadNoExisteException)
                {
                    throw new EntidadNoExisteException($"Alguna de las polizas no existe");
                }
            }
        }

        private async Task ExecuteRemovePolizas(Cliente cliente, IEnumerable<int> remove)
        {
            if (remove.Any())
            {
                var removerPolizas = new List<AsignacionPoliza>();
                foreach (var polizaId in remove)
                {
                    try
                    {
                        var poliza = await _unitOfWork.Polizas.GetByIdAsync(polizaId).ConfigureAwait(false);
                        var asignacionPoliza = new AsignacionPoliza(cliente, poliza);
                        removerPolizas.Add(asignacionPoliza);
                    }
                    catch (EntidadNoExisteException)
                    {
                        throw new EntidadNoExisteException($"La poliza {polizaId} does not exist");
                    }
                }
                await _unitOfWork.Clientes.RemoverPolizas(removerPolizas).ConfigureAwait(false);
            }
            
        }

        private async Task ExecuteAddPolizas(Cliente cliente, IEnumerable<int> add)
        {
            if (add.Any())
            {
                var asignarPolizas = new List<AsignacionPoliza>();
                foreach (var polizaId in add)
                {
                    try
                    {
                        var poliza = await _unitOfWork.Polizas.GetByIdAsync(polizaId).ConfigureAwait(false);
                        var asignacionPoliza = new AsignacionPoliza(cliente, poliza);
                        asignarPolizas.Add(asignacionPoliza);
                    }
                    catch (EntidadNoExisteException)
                    {
                        throw new EntidadNoExisteException($"La poliza {polizaId} does not exist");
                    }
                }
                await _unitOfWork.Clientes.AsignarPolizas(asignarPolizas).ConfigureAwait(false);
            }
        }
    }
}
