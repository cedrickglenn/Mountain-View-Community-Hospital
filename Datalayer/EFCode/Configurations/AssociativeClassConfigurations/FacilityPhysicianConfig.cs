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
    public class FacilityPhysicianConfig : IEntityTypeConfiguration<FacilityPhysician>
    {
        
        public void Configure(EntityTypeBuilder<FacilityPhysician> builder)
        {
            builder.ToTable("FacilityPhysician");
            builder.HasKey(c => c.FacilityPhysicianId);
            builder.Property(c => c.FacilityPhysicianId)
                .HasValueGenerator(typeof(FacilityPhysicianIdGenerator));



            builder.HasOne(c => c.PhysicianLink)
                .WithMany(c => c.FacilityPhysicians)
                .HasForeignKey(c => c.PhysicianId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.FacilityLink)
                .WithMany(c => c.FacilityPhysicians)
                .HasForeignKey(c => c.FacilityId).OnDelete(DeleteBehavior.NoAction);
        }
        private class FacilityPhysicianIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.FacilityPhysicians.Count() + 1).ToString();

                stringId.Append("FPN-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
