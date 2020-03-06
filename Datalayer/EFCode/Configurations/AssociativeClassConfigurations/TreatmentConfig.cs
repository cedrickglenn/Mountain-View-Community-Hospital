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
    public class TreatmentConfig : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder.ToTable("Treatment");
            builder.HasKey(c => c.TreatmentId);
            builder.Property(c => c.TreatmentId)
                .HasValueGenerator(typeof(TreatmentIdGenerator));

            builder.HasOne(c => c.PhysicianLink)
                .WithMany(c => c.Treatments)
                .HasForeignKey(c => c.PhysicianId);
            builder.HasOne(c => c.PatientLink)
                .WithMany(c => c.Treatments)
                .HasForeignKey(c => c.PatientId);
            builder.HasOne(c => c.ServiceLink)
                .WithMany(c => c.Treatments)
                .HasForeignKey(c => c.ServiceId);
        }
        
        
        private class TreatmentIdGenerator : ValueGenerator
        {

            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Treatments.Count() + 1).ToString();

                stringId.Append("TRT-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }


        
    }
}
