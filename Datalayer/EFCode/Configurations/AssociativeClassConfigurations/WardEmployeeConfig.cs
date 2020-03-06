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
    public class WardEmployeeConfig : IEntityTypeConfiguration<WardEmployee>
    {
        public void Configure(EntityTypeBuilder<WardEmployee> builder)
        {
            builder.ToTable("WardEmployee");
            builder.HasKey(c => c.WardEmployeeId);
            builder.Property(c => c.WardEmployeeId)
                .HasValueGenerator(typeof(WardEmployeeIdGenerator));

            builder.HasOne(c => c.EmployeeLink)
                .WithMany(c => c.WardEmployees)
                .HasForeignKey(c => c.EmployeeId);
            builder.HasOne(c => c.WardLink)
                .WithMany(c => c.WardEmployees)
                .HasForeignKey(c => c.WardId);
        }
       

        private class WardEmployeeIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.WardEmployees.Count() + 1).ToString();

                stringId.Append("WEM-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }


        
    }
}
