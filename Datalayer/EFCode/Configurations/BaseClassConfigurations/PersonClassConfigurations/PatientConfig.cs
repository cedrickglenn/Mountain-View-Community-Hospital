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
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            //builder.ToTable("Patient");


            builder.HasOne(c => c.ContactPersonLink)
                .WithMany(c => c.PatientContacts)
                .HasForeignKey(c => c.ContactPersonId);
            builder.HasOne(c => c.SubscriberPersonLink)
                .WithMany(c => c.Dependents)
                .HasForeignKey(c => c.SubscriberPersonId);
        }
    }
    }

