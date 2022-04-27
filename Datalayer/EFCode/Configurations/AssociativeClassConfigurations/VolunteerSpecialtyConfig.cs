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
    public class VolunteerSpecialtyConfig : IEntityTypeConfiguration<VolunteerSpecialty>
    {
        public void Configure(EntityTypeBuilder<VolunteerSpecialty> builder)
        {
            builder.ToTable("VolunteerSpecialty");
            builder.HasKey(c => c.VolunteerSpecialtyId);
            builder.Property(c => c.VolunteerSpecialtyId)
                .HasValueGenerator(typeof(VolunteerSpecialtyIdGenerator));


            builder.HasOne(c => c.VolunteerLink)
                .WithMany(c => c.VolunteerSpecialties)
                .HasForeignKey(c => c.VolunteerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.SpecialtyLink)
                .WithMany(c => c.VolunteerSpecialties)
                .HasForeignKey(c => c.SpecialtyId).OnDelete(DeleteBehavior.NoAction);
        }
        
        
        private class VolunteerSpecialtyIdGenerator : ValueGenerator
        {

            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.VolunteerSpecialties.Count() + 1).ToString();

                stringId.Append("VSP-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }


        
    }
}
