using SegurosTestGAP.Dominio.Polizas;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SegurosTestGAP.Aplicacion.Polizas.Repositorios
{
    public interface IPolizaRepositorio : IRepository<Poliza>
    {
        Task<bool> ExistPolizaAsync(int tipoRiesgoId, int tipoCubrimientoId, int periodoCobertura, int porcentajeCobertura, DateTime inicioVigencia, int? id);
        
        Task<Poliza> InsertPoliza(Poliza poliza);

        Task ActualizarPoliza(int id, Poliza poliza);

        Task<IEnumerable<Poliza>> GetAllPolizasAsync();
    }
}
