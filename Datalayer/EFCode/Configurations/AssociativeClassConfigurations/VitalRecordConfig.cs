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
    public class VitalRecordConfig : IEntityTypeConfiguration<VitalRecord>
    {
        public void Configure(EntityTypeBuilder<VitalRecord> builder)
        {
            builder.ToTable("VitalRecord");
            builder.HasKey(c => c.VitalRecordId);
            builder.Property(c => c.VitalRecordId)
                .HasValueGenerator(typeof(VitalRecordIdGenerator));


            builder.HasOne(c => c.PatientLink)
                .WithMany(c => c.VitalRecords)
                .HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.NurseLink)
                .WithMany(c => c.VitalRecords)
                .HasForeignKey(c => c.NurseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.VitalLink)
                .WithMany(c => c.VitalRecords)
                .HasForeignKey(c => c.VitalId).OnDelete(DeleteBehavior.NoAction);
        }
        
        private class VitalRecordIdGenerator : ValueGenerator
        {

            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.VitalRecords.Count() + 1).ToString();

                stringId.Append("VRS-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }


       
    }
}
