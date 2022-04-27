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
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");
            builder.HasKey(c => c.OrderItemId);
            builder.Property(c => c.OrderItemId)
                .HasValueGenerator(typeof(OrderItemIdGenerator));
       


            builder.HasOne(c => c.ItemLink)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(c => c.ItemId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.PatientOrderLink)
                .WithMany(c => c.OrderItems)
                .HasForeignKey(c => c.PatientOrderId).OnDelete(DeleteBehavior.NoAction);
        }

        private class OrderItemIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.OrderItems.Count() + 1).ToString();

                stringId.Append("OIM-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
