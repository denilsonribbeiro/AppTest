using AppTest.Application.Interfaces;
using AppTest.Application.Services;
using AppTest.Infra.Contexts;
using AppTest.Infra.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTest.Api
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
            services.AddInfra(Configuration);
            services.AddControllers();
            //var connectionString = Configuration.GetConnectionString("SqlConnection");
            //services.AddDbContext<AppTestContext>(options => options.UseSqlServer(connectionString, s => s.MigrationsAssembly("AppTest.Infra")));

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IContatoService, ContatoService>();

            services.AddSwaggerGen(config => {
                config.ResolveConflictingActions(apiRoute => apiRoute.First());
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MEDGroupApi - v1",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI( config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "MEDGroupApi");
                config.RoutePrefix = "swagger";

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
