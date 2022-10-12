using Allocations.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocations.Core.Ef.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

            builder.Property(e => e.BirthDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.StartDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50);

            builder.Property(e => e.HourCost)
                .IsRequired()
                .HasColumnType("money");

            builder.HasMany(e => e.TimeSheets)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.IdEmployee);




        }
        }

    }
