using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backendRCVUcab.Persistence.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RCVUcabBackend.Persistence.DAOs.Implementations;
using RCVUcabBackend.Persistence.DAOs.Interfaces;

namespace RCVUcabBackend
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
            services.AddControllers();
            services.AddDbContext<RCVDbContext>(options => 
                options.UseNpgsql(
                    Configuration["DBConnectionString"], 
                    x => x.UseNetTopologySuite()
                )
            );
            services.AddTransient<IRCVDbContext, RCVDbContext>();
            //Implementar la inyeccion de sus entidades
            
             services.AddTransient<IProveedorDAO, ProveedorDao>();
             
             services.AddTransient<ISolicitudDAO, SolicitudDao>();
             
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "proveedor", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "proveedor v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}