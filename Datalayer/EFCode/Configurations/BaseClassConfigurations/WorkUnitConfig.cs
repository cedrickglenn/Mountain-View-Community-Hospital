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
    public class WorkUnitConfig : IEntityTypeConfiguration<WorkUnit>
    {
        public void Configure(EntityTypeBuilder<WorkUnit> builder)
        {
            builder.ToTable("WorkUnit");
            builder.HasKey(c => c.WorkUnitId);
            builder.Property(c => c.WorkUnitId)
                .HasValueGenerator(typeof(WorkUnitIdGenerator));

            builder.HasOne(c => c.FacilityLink)
                .WithMany(c => c.WorkUnits)
                .HasForeignKey(c => c.FacilityId);
        }

        private class WorkUnitIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.WorkUnits.Count() + 1).ToString();

                stringId.Append("WKS-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
