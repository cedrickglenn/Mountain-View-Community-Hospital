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
    public class VendorSupplyConfig : IEntityTypeConfiguration<VendorSupply>
    {
        public void Configure(EntityTypeBuilder<VendorSupply> builder)
        {
            builder.ToTable("VendorSupply");
            builder.HasKey(c => c.VendorSupplyId);
            builder.Property(c => c.VendorSupplyId)
                .HasValueGenerator(typeof(VendorSupplyIdGenerator));
            

            builder.HasOne(c => c.VendorLink)
                .WithMany(c => c.VendorSupplies)
                .HasForeignKey(c => c.VendorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.ItemLink)
                .WithMany(c => c.VendorSupplies)
                .HasForeignKey(c => c.ItemId).OnDelete(DeleteBehavior.NoAction);
        }
        
        private class VendorSupplyIdGenerator : ValueGenerator
        {

            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.VendorSupplies.Count() + 1).ToString();

                stringId.Append("VSP-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }


        
    }
}
