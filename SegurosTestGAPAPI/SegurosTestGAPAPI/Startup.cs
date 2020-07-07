using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SegurosTestGAP.Aplicacion;
using SegurosTestGAP.Aplicacion.Clientes.Comandos;
using SegurosTestGAP.Aplicacion.Clientes.Comandos.Crear;
using SegurosTestGAP.Aplicacion.Clientes.Comandos.PatchPoliza;
using SegurosTestGAP.Aplicacion.Clientes.Repositorios;
using SegurosTestGAP.Aplicacion.Clientes.TiposDocumentos;
using SegurosTestGAP.Aplicacion.Clientes.TiposDocumentos.Consultas.ObtenerTipoDocumento;
using SegurosTestGAP.Aplicacion.Polizas;
using SegurosTestGAP.Aplicacion.Polizas.Comandos.Actualizar;
using SegurosTestGAP.Aplicacion.Polizas.Comandos.Borrar;
using SegurosTestGAP.Aplicacion.Polizas.Comandos.Crear;
using SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerPolizaPorId;
using SegurosTestGAP.Aplicacion.Polizas.Consultas.ObtenerTodasPolizas;
using SegurosTestGAP.Aplicacion.Polizas.Repositorios;
using SegurosTestGAP.Aplicacion.Polizas.TiposCubrimientos;
using SegurosTestGAP.Aplicacion.Polizas.TiposCubrimientos.Consultas.ObtenerTipoCubrimiento;
using SegurosTestGAP.Aplicacion.Polizas.TiposRiesgos;
using SegurosTestGAP.Aplicacion.Polizas.TiposRiesgos.Consultas.ObtenerTipoRiesgo;
using SegurosTestGAP.Persistencia;
using SegurosTestGAP.Persistencia.Clientes;
using SegurosTestGAP.Persistencia.Polizas;
using SegurosTestGAP.Persistencia.SqlGenerator;
using SegurosTestGAPAPI.Clientes;
using SegurosTestGAPAPI.Polizas;

namespace SegurosTestGAPAPI
{
    public class Startup
    {
        private readonly string _appName = "SegurosTestGAP.Aplicacion";
        private readonly string _allowedOriginsPolicyName = "_allowedOriginsPolicyName";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy(_allowedOriginsPolicyName,
                builder =>
                {
                    builder
                        .WithOrigins(Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>())
                        .WithMethods(Configuration.GetSection("Cors:AllowedMethods").Get<string[]>() ?? Array.Empty<string>())
                        .AllowAnyHeader();
                });
            });
            services.AddControllers();

            services.AddScoped<IDbConnection>(_ => new SqlConnection(Configuration.GetConnectionString("SegurosDataBase")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<ITipoDocumentoRepositorio, TipoDocumentoRepositorio>();
            services.AddScoped<IPolizaRepositorio, PolizaRepositorio>();
            services.AddScoped<ITipoCubrimientoRepositorio, TipoCubrimientoRepositorio>();
            services.AddScoped<ITipoRiesgoRepositorio, TipoRiesgoRepositorio>();

            services.AddScoped<ISqlGenerator, BaseSqlGenerator>();
            services.AddScoped<IClienteSqlGenerator, ClienteSqlGenerator>();
            services.AddScoped<ITipoDocumentoSqlGenerator, TipoDocumentoSqlGenerator>();
            services.AddScoped<IPolizaSqlGenerator, PolizaSqlGenerator>();
            services.AddScoped<ITipoCubrimientoSqlGenerator, TipoCubrimientoSqlGenerator>();
            services.AddScoped<ITipoRiesgoSqlGenerator, TipoRiesgoSqlGenerator>();

            services.AddScoped<ICommandHandler<CrearPolizaCommand, PolizaViewModel>, CrearPolizaCommandHandler>();
            services.AddScoped<ICommandHandler<CrearClienteCommand, ClienteViewModel>, CrearClienteCommandHandler>();

            services.AddScoped<IVoidCommandHandler<BorrarPolizaPorIdCommand>, BorrarPolizaPorIdCommandHandler>();
            services.AddScoped<IVoidCommandHandler<ActualizarPolizaCommand>, ActualizarPolizaCommandHandler>();
            services.AddScoped<IVoidCommandHandler<PatchClienteCommand>, PatchClienteCommandHandler>();

            services.AddScoped<IQueryHandler<ObtenerTodosTiposDocumentoQuery, IEnumerable<TipoDocumentoViewModel>>, ObtenerTodosTiposDocumentoQueryHandler>();
            services.AddScoped<IQueryHandler<ObtenerTodosTiposCubrimientosQuery, IEnumerable<TipoCubrimientoViewModel>>, ObtenerTodosTiposCubrimientosQueryHandler>();
            services.AddScoped<IQueryHandler<ObtenerTodosTiposRiesgosQuery, IEnumerable<TipoRiesgoViewModel>>, ObtenerTodosTiposRiesgosQueryHandler>();
            services.AddScoped<IQueryHandler<ObtenerPolizaPorIdQuery, PolizaViewModel>, ObtenerPolizaPorIdQueryQueryHandler>();
            services.AddScoped<IQueryHandler<ObtenerPolizasQuery, IEnumerable<PolizaViewModel>>, ObtenerPolizasQueryHandler>();

            services.AddScoped<PolizaErrorMessages, PolizaErrorMessages>();
            services.AddScoped<ClienteErrorMessages, ClienteErrorMessages>();

            services.AddLocalization();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = _appName, Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(_allowedOriginsPolicyName);

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", _appName);
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
