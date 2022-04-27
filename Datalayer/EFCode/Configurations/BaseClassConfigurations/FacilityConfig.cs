using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Datalayer.EFCode.Configurations.BaseClassConfigurations
{
    public class FacilityConfig : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.ToTable("Facility");
            builder.HasKey(c => c.FacilityId);
            builder.Property(c => c.FacilityId)
                .HasValueGenerator(typeof(FacilityIdGenerator));
          
        }

        private class FacilityIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Facilities.Count() + 1).ToString();

                stringId.Append("FAC-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }

    }
}
