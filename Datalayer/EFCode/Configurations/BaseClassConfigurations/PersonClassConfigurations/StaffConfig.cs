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
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            //builder.ToTable("Staff");

            builder.HasOne(c => c.JobClassLink)
                .WithMany(c => c.Staff)
                .HasForeignKey(c => c.JobClassId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
