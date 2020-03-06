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
    public class PhysicianSpecialtyConfig : IEntityTypeConfiguration<PhysicianSpecialty>
    {
        public void Configure(EntityTypeBuilder<PhysicianSpecialty> builder)
        {
            builder.ToTable("PhysicianSpecialty");
            builder.HasKey(c => c.PhysicianSpecialtyId);
            builder.Property(c => c.PhysicianSpecialtyId)
                .HasValueGenerator(typeof(PhysicianSpecialtyIdGenerator));

            builder.HasOne(c => c.PhysicianLink)
                .WithMany(c => c.PhysicianSpecialties)
                .HasForeignKey(c => c.PhysicianId);
            builder.HasOne(c => c.SpecialtyLink)
                .WithMany(c => c.PhysicianSpecialties)
                .HasForeignKey(c => c.SpecialtyId);
        }
        
        private class PhysicianSpecialtyIdGenerator : ValueGenerator
        {

            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.PhysicianSpecialties.Count() + 1).ToString();

                stringId.Append("PSP-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }


        
    }
}
