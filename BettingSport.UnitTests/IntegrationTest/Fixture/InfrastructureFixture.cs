using BettingSport.Core.Entities;
using BettingSport.Core.Interfaces;
using BettingSport.EfInfrastructure.AccessData;
using BettingSport.EfInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BettingSport.Tests.IntegrationTest.Fixture
{
    public class InfrastructureFixture : IDisposable
    {
        ServiceCollection services;
        ServiceProvider serviceProvider;

        public IServiceProvider ServiceProvider { get { return serviceProvider;  } }
        public SportEvent DefaultEvent { get; private set; }
        public InfrastructureFixture()
        {
            var container = new Container();
            services = new ServiceCollection();


            services.AddDbContext<BettingSportContext>(options =>
                {
                    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BettingSportTest;Trusted_Connection=True;");
                }, ServiceLifetime.Singleton);

            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IReadonlyRepository<>), typeof(EfRepository<>));
            services.AddTransient(typeof(IAsyncReadonlyRepository<>), typeof(EfRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAsyncUnitOfWork, UnitOfWork>();

            serviceProvider = services.BuildServiceProvider(validateScopes: true);

            SeedData();
        }

        void SeedData()
        {
            var context = ServiceProvider.GetService<BettingSportContext>();
            context.Database.EnsureCreated();

            // Saving created to have reference to its Id since the Database is created only one time
            DefaultEvent = context.SportEvents.Add(new SportEvent()
            {
                Name = "Test Event",
                OddsForDraw = 1,
                OddsForFirstTeam = 1,
                OddsForSecondTeam = 1,
                StartDate = DateTime.Now
            }).Entity;

            context.SaveChanges();
        }

        void CleanData()
        {
            var context = ServiceProvider.GetService<BettingSportContext>();

            context.SportEvents.RemoveRange(context.SportEvents.ToList());
            context.SaveChanges();
        }

        public void Dispose()
        {
            CleanData();
            serviceProvider.Dispose();
        }
    }
}
