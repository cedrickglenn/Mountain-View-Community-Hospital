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
    public class OutpatientConfig : IEntityTypeConfiguration<Outpatient>
    {
        public void Configure(EntityTypeBuilder<Outpatient> builder)
        {
            //builder.ToTable("Outpatient");
            
            builder.Property(c => c.OutpatientId)
                .HasValueGenerator(typeof(OutpatientIdGenerator));
            builder.HasIndex(c => c.OutpatientId)
                .IsUnique();
        }
        private class OutpatientIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Outpatients.Count() + 1).ToString();

                stringId.Append("OTP-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
