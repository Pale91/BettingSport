using BettingSport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BettingSport.EfInfrastructure.Data.Configurations
{
    internal class SportEventConfiguration : BaseConfiguration<SportEvent>
    {
        public override void Configure(EntityTypeBuilder<SportEvent> builder)
        {
            base.Configure(builder);
            // This configuration matches the default configurations used by EF by just reading the SportEvent class
            // The intention is to show the use of configurations and explicitly set the required field for easy code reading

            // Choosing odds to be nullable/not required because from the description of the task "in the storage are saved only EventID and EventStartDate"

            builder.Property(e => e.Name).IsRequired(false);
            builder.Property(e => e.OddsForFirstTeam).IsRequired(false);
            builder.Property(e => e.OddsForDraw).IsRequired(false);
            builder.Property(e => e.OddsForSecondTeam).IsRequired(false);
            builder.Property(e => e.StartDate).IsRequired().HasConversion(
                entityValue => entityValue,
                dbValue => DateTime.SpecifyKind(dbValue, DateTimeKind.Utc)); // Setting Kind as UTC (dates are saved as UTC), when retrieved from DB the Kind property is set to Unspecified
        }
    }
}
