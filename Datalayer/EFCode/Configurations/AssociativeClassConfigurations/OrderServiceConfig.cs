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
    public class OrderServiceConfig : IEntityTypeConfiguration<OrderService>
    {
        public void Configure(EntityTypeBuilder<OrderService> builder)
        {
            builder.ToTable("OrderService");
            builder.HasKey(c => c.OrderServiceId);
            builder.Property(c => c.OrderServiceId)
                .HasValueGenerator(typeof(OrderServiceIdGenerator));

            builder.HasOne(c => c.ServiceLink)
                .WithMany(c => c.OrderServices)
                .HasForeignKey(c => c.ServiceId);
            builder.HasOne(c => c.OrderLink)
                .WithMany(c => c.OrderServices)
                .HasForeignKey(c => c.OrderId);
        }

        private class OrderServiceIdGenerator : ValueGenerator
        {

            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.OrderServices.Count() + 1).ToString();

                stringId.Append("OSC-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }

        
    }
}
