using System;
using System.Collections.Generic;
using System.Text;
using Datalayer.EFClasses.BaseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Datalayer.EFCode.Configurations.BaseClassConfigurations
{
    public class ProcedureConfig : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.ToTable("Procedure");
            builder.HasKey(c => c.ProcedureId);
        }
    }
}
