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
            builder.HasOne(c => c.BedLink)
                .WithMany(c => c.Inpatients)
                .HasForeignKey(c => c.BedId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.WardLink)
                .WithMany(c => c.Inpatients)
                .HasForeignKey(c => c.WardId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}



