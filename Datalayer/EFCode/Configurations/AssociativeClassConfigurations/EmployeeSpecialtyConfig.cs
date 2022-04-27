using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.AssociativeClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Datalayer.EFCode.Configurations.AssociativeClassConfigurations
{
    public class EmployeeSpecialtyConfig : IEntityTypeConfiguration<EmployeeSpecialty>
    {
        public void Configure(EntityTypeBuilder<EmployeeSpecialty> builder)
        {
            builder.ToTable("EmployeeSpecialty");
            builder.HasKey(c => c.EmployeeSpecialtyId);
            builder.Property(c => c.EmployeeSpecialtyId)
                .HasValueGenerator(typeof(EmployeeSpecialtyIdGenerator));



            builder.HasOne(c => c.SpecialtyLink)
                .WithMany(c => c.EmployeeSpecialties)
                .HasForeignKey(c => c.SpecialtyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.EmployeeLink)
                .WithMany(c => c.EmployeeSpecialties)
                .HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.NoAction);
        }

        private class EmployeeSpecialtyIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.EmployeeSpecialties.Count() + 1).ToString();

                stringId.Append("EMS-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
