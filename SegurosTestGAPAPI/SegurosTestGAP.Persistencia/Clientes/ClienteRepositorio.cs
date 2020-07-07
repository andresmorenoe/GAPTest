using Dapper;
using SegurosTestGAP.Aplicacion.Clientes.Repositorios;
using SegurosTestGAP.Dominio.Clientes;
using SegurosTestGAP.Persistencia.SqlGenerator;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using SegurosTestGAP.Aplicacion.Excepciones;
using SegurosTestGAP.Dominio.Polizas;

namespace SegurosTestGAP.Persistencia.Clientes
{
    public class ClienteRepositorio : Repository<Cliente>, IClienteRepositorio
    {
        private readonly IDbConnection _connection;
        private readonly IClienteSqlGenerator _sqlGenerator;

        public ClienteRepositorio(IDbConnection connection,
            IClienteSqlGenerator sqlGenerator) : base(connection, sqlGenerator)
        {
            _connection = connection;
            _sqlGenerator = sqlGenerator;
        }

        public async Task<bool> ExistByDocumentAsync(string documento)
        {
            var result = false;
            var parameters = new Dictionary<string, object>{
                { "Documento", documento }
            };
            var selectQuery = _sqlGenerator.BuildExistClienteQuery();
            var results = (await _connection.QueryAsync<Cliente>(selectQuery, parameters).ConfigureAwait(false)).ToList();

            if (results.Any())
            {
                result = true;
            }

            return result;
        }

        public async Task<Cliente> InsertCliente(Cliente cliente)
        {
            var parameters = _sqlGenerator.GetParametersForQuery(cliente);
            var insertQuery = _sqlGenerator.BuildInsertQuery();

            cliente.Id = await _connection.ExecuteScalarAsync<int>(insertQuery, parameters).ConfigureAwait(false);

            return cliente;
        }

        public async Task<Cliente> GetClienteById(int id) 
        {
            var getByIdSqlQuery = _sqlGenerator.BuildGetClientByIdSqlQuery();

            using var multi = await _connection.QueryMultipleAsync(getByIdSqlQuery, new { Id = id }).ConfigureAwait(false);

            var clientesMapeadas = new List<Cliente>();
            var clienteActual = multi.Read<Cliente, TipoDocumento, Cliente>(
                (cliente, tipoDocumento) =>
                {
                    Cliente clienteActual;

                    if (clientesMapeadas.All(p => p.Id != cliente.Id))
                    {
                        clienteActual = cliente;
                        clientesMapeadas.Add(cliente);
                    }
                    else
                    {
                        clienteActual = clientesMapeadas.Single(p => p.Id == cliente.Id);
                    }

                    clienteActual.TipoDocumento = tipoDocumento;

                    return clienteActual;
                });

            if (!clientesMapeadas.Any())
            {
                throw new EntidadNoExisteException($"Client does not exist.");

            }
            else
            {
                var cliente = clientesMapeadas.Single();
                return cliente;
            }
        }

        public async Task RemoverPolizas(List<AsignacionPoliza> removerPolizas)
        {
            foreach (var asignarPoliza in removerPolizas)
            {
                var removeAsignacionQuery = _sqlGenerator.BuildRemoverAsigacionQuery();
                var parametros = new Dictionary<string, object> { { "ClienteId", asignarPoliza.Cliente.Id }, { "PolizaId", asignarPoliza.Poliza.Id } };
                await _connection.ExecuteAsync(removeAsignacionQuery, parametros).ConfigureAwait(false);
            }
        }

        public async Task AsignarPolizas(List<AsignacionPoliza> asignarPolizas)
        {
            foreach (var asignarPoliza in asignarPolizas)
            {
                var insertAsignacionQuery = _sqlGenerator.BuildInsertAsigacionQuery();
                var parametros = new Dictionary<string, object> { { "ClienteId", asignarPoliza.Cliente.Id }, { "PolizaId", asignarPoliza.Poliza.Id } };
                await _connection.ExecuteAsync(insertAsignacionQuery, parametros).ConfigureAwait(false);
            }  
        }
    }
}
