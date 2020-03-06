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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(c => c.OrderId);
            builder.Property(c => c.OrderId)
                .HasValueGenerator(typeof(OrderIdGenerator));

            builder.HasOne(c => c.PhysicianLink)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.PhysicianId);
            builder.HasOne(c => c.PatientLink)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.PatientId);
        }

        private class OrderIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Orders.Count() + 1).ToString();

                stringId.Append("ORD-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
