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
    public class PhysicianConfig :IEntityTypeConfiguration<Physician>
    {
        public void Configure(EntityTypeBuilder<Physician> builder)
        {
            //builder.ToTable("Physician");
            builder.Property(c => c.PhysicianId)
                .HasValueGenerator(typeof(PhysicianIdGenerator));
            builder.HasIndex(c => c.PhysicianId)
                .IsUnique();

        }
        private class PhysicianIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Physicians.Count() + 1).ToString();

                stringId.Append("PHY-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }

    }
}
