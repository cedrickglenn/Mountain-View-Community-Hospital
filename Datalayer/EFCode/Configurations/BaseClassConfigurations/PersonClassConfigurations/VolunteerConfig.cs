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
    public class VolunteerConfig : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            //builder.ToTable("Volunteer");
            builder.Property(c => c.VolunteerId)
                .HasValueGenerator(typeof(VolunteerIdGenerator));

            builder.HasOne(c => c.SupervisorLink)
                .WithMany(c => c.Volunteers)
                .HasForeignKey(c => c.SupervisorId);
            builder.HasOne(c => c.WorkUnitLink)
                .WithMany(c => c.Volunteers)
                .HasForeignKey(c => c.WorkUnitId);
        }

        private class VolunteerIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.Volunteers.Count() + 1).ToString();

                stringId.Append("VOL-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }
    }
}
