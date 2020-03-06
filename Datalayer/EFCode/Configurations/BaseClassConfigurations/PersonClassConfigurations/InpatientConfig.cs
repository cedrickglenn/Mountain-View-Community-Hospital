using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses.PersonClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Datalayer.EFCode.Configurations.BaseClassConfigurations.PersonClassConfigurations
{
    public class InpatientConfig : IEntityTypeConfiguration<Inpatient>
    {
        public void Configure(EntityTypeBuilder<Inpatient> builder)
        {
            //builder.ToTable("Inpatient");
           
            builder.Property(c => c.InpatientId)
                .HasValueGenerator(typeof(InpatientIdGenerator));
            builder.HasIndex(c => c.InpatientId)
                .IsUnique();

            builder.HasOne(c => c.BedLink)
                .WithMany(c => c.Inpatients)
                .HasForeignKey(c => c.BedId);
            builder.HasOne(c => c.WardLink)
                .WithMany(c => c.Inpatients)
                .HasForeignKey(c => c.WardId);
        }

        private class InpatientIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Inpatients.Count() + 1).ToString();

                stringId.Append("INP-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
