using Dapper;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Aplicacion.Polizas.Repositorios;
using SegurosTestGAP.Dominio.Polizas;
using SegurosTestGAP.Persistencia.SqlGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SegurosTestGAP.Persistencia.Polizas
{
    public class PolizaRepositorio : Repository<Poliza>, IPolizaRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IPolizaSqlGenerator _sqlGenerator;

        public PolizaRepositorio(IDbConnection connection,
            IPolizaSqlGenerator sqlGenerator) : base(connection, sqlGenerator)
        {
            _connection = connection;
            _sqlGenerator = sqlGenerator;
        }

        public async Task<bool> ExistPolizaAsync(int tipoRiesgoId, int tipoCubrimientoId, int periodoCobertura, int porcentajeCobertura, DateTime inicioVigencia, int? Id)
        {
            var result = false;
            var parameters = new Dictionary<string, object>{
                { "TipoRiesgoId", tipoRiesgoId },
                { "TipoCubrimientoId", tipoCubrimientoId },
                { "PeriodoCobertura", periodoCobertura },
                { "PorcentajeCobertura", porcentajeCobertura },
                { "InicioVigencia", inicioVigencia }
            };
            if (Id != null)
            {
                parameters.Add("Id", Id);
            }
            var selectQuery = _sqlGenerator.BuildExistPolizaQuery(Id);
            var results = (await _connection.QueryAsync<Poliza>(selectQuery, parameters).ConfigureAwait(false)).ToList();

            if (results.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<Poliza> InsertPoliza(Poliza poliza)
        {
            var parameters = _sqlGenerator.GetParametersForQuery(poliza);
            var insertQuery = _sqlGenerator.BuildInsertQuery();

            poliza.Id = await _connection.ExecuteScalarAsync<int>(insertQuery, parameters).ConfigureAwait(false);

            return poliza;
        }

        public async Task<Poliza> GetByIdAsync(int id)
        {
            var getByIdSqlQuery = _sqlGenerator.BuildGetByIdSqlQuery();

            using var multi = await _connection.QueryMultipleAsync(getByIdSqlQuery, new { Id = id }).ConfigureAwait(false);

            var polizasMapeadas = new List<Poliza>();
            var polizaActual = multi.Read<Poliza, TipoCubrimiento, TipoRiesgo, Poliza>(
                (poliza, tipoCubrimiento, tipoRiesgo) =>
                {
                    Poliza polizaActual;

                    if (polizasMapeadas.All(p => p.Id != poliza.Id))
                    {
                        polizaActual = poliza;
                        polizasMapeadas.Add(poliza);
                    }
                    else
                    {
                        polizaActual = polizasMapeadas.Single(p => p.Id == poliza.Id);
                    }

                    polizaActual.TipoCubrimiento = tipoCubrimiento;
                    polizaActual.TipoRiesgo = tipoRiesgo;

                    return polizaActual;
                });

            if (!polizasMapeadas.Any())
            {
                throw new EntidadNoExisteException($"Poliza does not exist.");

            }
            else
            {
                var poliza = polizasMapeadas.Single();
                return poliza;
            }
        }

        public async Task ActualizarPoliza(int id, Poliza poliza)
        {
            var actualizarQuery = _sqlGenerator.BuildUpdateSqlCommand("Poliza", id, poliza, out var outputParameters);
            await _connection.ExecuteAsync(actualizarQuery, outputParameters).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Poliza>> GetAllPolizasAsync()
        {
            var getAllSqlQuery = _sqlGenerator.BuildGetAllSqlQuery();

            using var multi = await _connection.QueryMultipleAsync(getAllSqlQuery).ConfigureAwait(false);

            var polizasMapeadas = new List<Poliza>();
            var polizaActual = multi.Read<Poliza, TipoCubrimiento, TipoRiesgo, Poliza>(
                (poliza, tipoCubrimiento, tipoRiesgo) =>
                {
                    Poliza polizaActual;

                    if (polizasMapeadas.All(p => p.Id != poliza.Id))
                    {
                        polizaActual = poliza;
                        polizasMapeadas.Add(poliza);
                    }
                    else
                    {
                        polizaActual = polizasMapeadas.Single(p => p.Id == poliza.Id);
                    }

                    polizaActual.TipoCubrimiento = tipoCubrimiento;
                    polizaActual.TipoRiesgo = tipoRiesgo;

                    return polizaActual;
                });

            return polizasMapeadas;
        }
    }
}
