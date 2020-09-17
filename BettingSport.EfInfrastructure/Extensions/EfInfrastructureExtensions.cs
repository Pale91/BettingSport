using BettingSport.Core.Interfaces;
using BettingSport.EfInfrastructure.AccessData;
using BettingSport.EfInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BettingSport.EfInfrastructure.Extensions
{
    public static class EfInfrastructureExtensions
    {
        public static void AddEf(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BettingSportContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BettingSportContext")));

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadonlyRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncReadonlyRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAsyncUnitOfWork, UnitOfWork>();
        }
    }
}
