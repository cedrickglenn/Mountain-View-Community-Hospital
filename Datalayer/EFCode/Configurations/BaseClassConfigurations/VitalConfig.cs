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
    public class VitalConfig : IEntityTypeConfiguration<Vital>
    {
        public void Configure(EntityTypeBuilder<Vital> builder)
        {
            builder.ToTable("Vital");
            builder.HasKey(c => c.VitalId);
            builder.Property(c => c.VitalId)
                .HasValueGenerator(typeof(VitalIdGenerator));

        }

        private class VitalIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Vitals.Count() + 1).ToString();

                stringId.Append("VTL-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
