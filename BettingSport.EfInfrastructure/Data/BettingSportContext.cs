using BettingSport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BettingSport.EfInfrastructure.Data
{
    public class BettingSportContext : DbContext
    {
        public BettingSportContext(DbContextOptions<BettingSportContext> options): base(options)
        {

        }
        public DbSet<SportEvent> SportEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(BettingSportContext).Assembly);
        }

    }
}
