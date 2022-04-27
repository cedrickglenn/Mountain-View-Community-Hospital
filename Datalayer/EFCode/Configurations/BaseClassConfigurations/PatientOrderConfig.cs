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
    public class PatientOrderConfig : IEntityTypeConfiguration<PatientOrder>
    {
        public void Configure(EntityTypeBuilder<PatientOrder> builder)
        {
            builder.ToTable("PatientOrder");
            builder.HasKey(c => c.PatientOrderId);
            builder.Property(c => c.PatientOrderId)
                .HasValueGenerator(typeof(PatientOrderIdGenerator));
            builder.Property(c => c.TotalCost);


           builder.HasOne(c => c.PatientLink)
                .WithMany(c => c.PatientOrders)
                .HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.NoAction);
        }
        private class PatientOrderIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.PatientOrders.Count() + 1).ToString();

                stringId.Append("POR-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
