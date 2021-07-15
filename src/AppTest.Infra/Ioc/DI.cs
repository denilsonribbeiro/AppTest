using AppTest.Domain.Interfaces;
using AppTest.Infra.Contexts;
using AppTest.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Infra.Ioc
{
    public static class DI
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppTestContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                i => i.MigrationsAssembly(typeof(AppTestContext).Assembly.FullName)));

            services.AddScoped<IContatoRepository, ContatoRepository>();

            return services;
        }
    }
}
