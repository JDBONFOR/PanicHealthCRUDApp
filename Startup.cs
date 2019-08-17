using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using PanicHealth.Models;
using PanicHealth.Repository;

namespace PanicHealth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Agrego el contexto al proyecto.
            var connection = Configuration.GetConnectionString("panicHealth");
            services.AddDbContext<panicHealthAppContext>(opt =>
                opt.UseMySql(connection));

            services.AddScoped<UsuarioRepository>();
            services.AddScoped<ProfesionalRepository>();
            services.AddScoped<PacienteRepository>();
            services.AddScoped<PacienteContactoRepository>();
            services.AddScoped<PacienteHistorialRepository>();

            services.AddScoped<AccionTipoRepository>();
            services.AddScoped<ObraSocialRepository>();
            services.AddScoped<TipoDocumentoRepository>();
            services.AddScoped<TipoFamiliarRepository>();
            services.AddScoped<UsuarioEstadoRepository>();
            services.AddScoped<UsuarioTipoRepository>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
