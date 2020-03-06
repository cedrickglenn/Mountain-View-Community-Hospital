using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datalayer.EFClasses;
using Datalayer.EFClasses.BaseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Datalayer.EFCode.Configurations.BaseClassConfigurations
{
    public class JobClassConfig : IEntityTypeConfiguration<JobClass>
    {
        public void Configure(EntityTypeBuilder<JobClass> builder)
        {
            builder.ToTable("JobClass");
            builder.HasKey(c => c.JobClassId);
            builder.Property(c => c.JobClassId)
                .HasValueGenerator(typeof(JobClassIdGenerator));

        }
        private class JobClassIdGenerator : ValueGenerator
        {
            public override bool GeneratesTemporaryValues => false;

            protected override object NextValue(EntityEntry entry)
            {
                using var context = new MVCHContext();

                var stringId = new StringBuilder();

                var idNumSequence = (context.JobClasses.Count() + 1).ToString();

                stringId.Append("JOB-");
                stringId.Append($"{idNumSequence.PadLeft(6, '0')}");

                return stringId.ToString();
            }
        }

    }
}
