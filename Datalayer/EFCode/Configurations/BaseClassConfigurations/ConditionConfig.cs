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
    public class ConditionConfig : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.ToTable("Condition");
            builder.HasKey(c => c.ConditionId);

        }
    }
}
