using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Datalayer.EFCode.Configurations.BaseClassConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Datalayer.EFCode.Configurations.AssociativeClassConfigurations
{
    public class UnitEmployeeConfig : IEntityTypeConfiguration<UnitEmployee>
    {
        public void Configure(EntityTypeBuilder<UnitEmployee> builder)
        {
            builder.ToTable("UnitEmployee");
            builder.HasKey(c => c.UnitEmployeeId);
            builder.Property(c => c.UnitEmployeeId)
                .HasValueGenerator(typeof(UnitEmployeeIdGenerator));

            builder.HasOne(c => c.EmployeeLink)
                .WithMany(c => c.UnitEmployees)
                .HasForeignKey(c => c.EmployeeId);
            builder.HasOne(c => c.WorkUnitLink)
                .WithMany(c => c.UnitEmployees)
                .HasForeignKey(c => c.WorkUnitId);
        }

        
        private class UnitEmployeeIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.UnitEmployees.Count() + 1).ToString();

                stringId.Append("UEM-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }

        
    }
}
