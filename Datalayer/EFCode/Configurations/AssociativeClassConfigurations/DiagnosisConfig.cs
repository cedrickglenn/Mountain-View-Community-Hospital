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
    public class DiagnosisConfig : IEntityTypeConfiguration<Diagnosis>
    {
        public void Configure(EntityTypeBuilder<Diagnosis> builder)
        {
            builder.ToTable("Diagnosis");
            builder.HasKey(c => c.DiagnosisId);
            builder.Property(c => c.DiagnosisId)
                .HasValueGenerator(typeof(DiagnosisIdGenerator));

            builder.HasOne(c => c.PatientLink)
                .WithMany(c => c.Diagnoses)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.HasOne(c => c.PhysicianLink)
                .WithMany(c => c.Diagnoses)
                .HasForeignKey(c => c.PhysicianId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
            builder.HasOne(c => c.ConditionLink)
                .WithMany(c => c.Diagnoses)
                .HasForeignKey(c => c.ConditionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }

        private class DiagnosisIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Diagnoses.Count() + 1).ToString();

                stringId.Append("DXS-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
