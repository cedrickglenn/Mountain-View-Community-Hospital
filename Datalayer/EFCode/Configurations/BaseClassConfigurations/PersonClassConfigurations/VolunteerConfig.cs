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
            builder.HasOne(c => c.SupervisorLink)
                .WithMany(c => c.Volunteers)
                .HasForeignKey(c => c.SupervisorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.WorkUnitLink)
                .WithMany(c => c.Volunteers)
                .HasForeignKey(c => c.WorkUnitId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
