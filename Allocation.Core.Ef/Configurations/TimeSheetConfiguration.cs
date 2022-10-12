using Allocations.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef.Configurations
{
    public class TimeSheetConfiguration : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.ToTable("Timesheet");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HourActivity)
                .IsRequired()
                .HasConversion(new TimeSpanToTicksConverter())
                .HasColumnType("float(4,2)");

            builder.Property(x => x.StartActivity)
                .IsRequired()
                .HasColumnType("datetime");

        }
    }
}
